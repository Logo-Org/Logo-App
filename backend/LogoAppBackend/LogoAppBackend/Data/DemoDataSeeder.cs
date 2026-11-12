using LogoAppBackend.Entities;

using Task = System.Threading.Tasks.Task;
using TaskStatus = LogoAppBackend.Entities.TaskStatus;

namespace LogoAppBackend.Data;

public class DemoDataSeeder(AppDbContext database) {

    public async Task SeedAsync() {
        List<Disorder> disorders = CreateDisorders();
        List<BodyPart> bodyParts = CreateBodyParts();
        List<SpeechSound> speechSounds = CreateSpeechSounds();

        List<Admin> admins = CreateAdmins();
        List<Exercise> exercises = CreateExercises(bodyParts, speechSounds, admins);

        List<Address> addresses = CreateAddresses();
        List<SpeechTherapist> speechTherapists = CreateSpeechTherapists(admins, addresses);
        List<Credential> credentials = CreateCredentials(speechTherapists);

        List<TherapyStage> therapyStages = CreateTherapyStages();
        List<Patient> patients = CreatePatients(admins, speechTherapists);
        List<TherapyPlan> therapyPlans = CreateTherapyPlans(therapyStages, disorders, patients);

        List<TherapyTask> tasks = CreateTherapyTasks(exercises, therapyPlans);
        List<Session> sessions = CreateSessions(tasks);
        List<Issue> issues = CreateIssues(sessions);

        database.AddRange(disorders);
        database.AddRange(bodyParts);
        database.AddRange(speechSounds);
        database.AddRange(exercises);
        database.Admin.AddRange(admins);
        database.SpeechTherapist.AddRange(speechTherapists);
        database.AddRange(credentials);
        database.Patient.AddRange(patients);
        database.AddRange(therapyPlans);
        database.AddRange(tasks);
        database.AddRange(sessions);
        database.AddRange(issues);

        await database.SaveChangesAsync();
    }


    private static List<TherapyTask> CreateTherapyTasks(List<Exercise> exercises, List<TherapyPlan> therapyPlans) {
        return [
            new TherapyTask {
                Timestamp = new DateTime(2026, 11, 4, 12, 0, 0, DateTimeKind.Utc),
                Series = 3,
                Repetition = 10,
                TaskStatus = TaskStatus.Completed,
                PeriodStartTime = new DateTime(2026, 11, 4, 0, 0, 0, DateTimeKind.Utc),
                PeriodEndTime = new DateTime(2026, 11, 10, 23, 59, 59, DateTimeKind.Utc),
                MaxSessionsPerPeriod = 5,
                Exercise = exercises[0],
                TherapyPlan = therapyPlans[0]
            },
            new TherapyTask {
                Timestamp = new DateTime(2026, 11, 6, 12, 0, 0, DateTimeKind.Utc),
                Series = 2,
                Repetition = 15,
                TaskStatus = TaskStatus.Pending,
                PeriodStartTime = new DateTime(2026, 11, 6, 0, 0, 0, DateTimeKind.Utc),
                PeriodEndTime = new DateTime(2026, 11, 13, 23, 59, 59, DateTimeKind.Utc),
                MaxSessionsPerPeriod = 3,
                Exercise = exercises[1],
                TherapyPlan = therapyPlans[1]
            },
            new TherapyTask {
                Timestamp = new DateTime(2026, 10, 27, 12, 0, 0, DateTimeKind.Utc),
                Series = 1,
                Repetition = 20,
                TaskStatus = TaskStatus.Missed,
                PeriodStartTime = new DateTime(2026, 10, 27, 0, 0, 0, DateTimeKind.Utc),
                PeriodEndTime = new DateTime(2026, 11, 2, 23, 59, 59, DateTimeKind.Utc),
                MaxSessionsPerPeriod = 2,
                Exercise = exercises[0],
                TherapyPlan = therapyPlans[0]
            }
        ];
    }

    private static List<Disorder> CreateDisorders() {
        return [
            new Disorder {
                Description = "Seplenienie międzyzębowe – język wsuwa się między zęby przy głoskach syczących",
                DisorderCategory = DisorderCategory.Kappacism
            },
            new Disorder {
                Description = "Osłabione napięcie mięśni warg.", DisorderCategory = DisorderCategory.Rhotacism
            }
        ];
    }

    private static List<BodyPart> CreateBodyParts() {
        return [
            new BodyPart { Description = "Język", BodyPartCategory = BodyPartCategory.Tongue },
            new BodyPart { Description = "Wargi", BodyPartCategory = BodyPartCategory.Lips }
        ];
    }

    private static List<SpeechSound> CreateSpeechSounds() {
        return [
            new SpeechSound {
                Description = "Głoska [r] – drżąca, przedniojęzykowa", SpeechSoundCategory = SpeechSoundCategory.R
            },
            new SpeechSound { Description = "Głoska [sz] – szumiąca", SpeechSoundCategory = SpeechSoundCategory.Sz }
        ];
    }

    private static List<Exercise> CreateExercises(List<BodyPart> bodyParts, List<SpeechSound> speechSounds,
        List<Admin> admins) {
        return [
            new Exercise {
                VideoRecordingInstruction = "\0\0\0\u0018ftypmp42"u8.ToArray(),
                Duration = TimeSpan.FromMinutes(2),
                Tags = [bodyParts[0], speechSounds[0]],
                StepByStepInstruction = [
                    "Usiądź prosto przed lustrem",
                    "Unieś czubek języka do wałka dziąsłowego",
                    "Wypowiadaj krótko „d-d-d” przez 30 sekund"
                ],
                Admin = admins[0]
            },
            new Exercise { Duration = TimeSpan.FromSeconds(45), Admin = admins[0] }
        ];
    }

    private static List<Admin> CreateAdmins() {
        return [
            new Admin {
                FirstName = "Kamil",
                LastName = "Kowalski",
                DateOfBirth = new DateTime(1987, 1, 22, 0, 0, 0, DateTimeKind.Utc),
                Contact = new Contact { PhoneNumber = "534102110", Email = "kamil.kowalski@logoapp.test" }
            },
            new Admin {
                FirstName = "Ewa",
                MiddleName = "Maria",
                LastName = "Nowak",
                DateOfBirth = new DateTime(1992, 3, 8, 0, 0, 0, DateTimeKind.Utc),
                Contact = new Contact { PhoneNumber = "533241229", Email = "ewa.nowak@logoapp.test" }
            }
        ];
    }

    private static List<Address> CreateAddresses() {
        return [
            new Address { Street = "ul. Marszałkowska 10/4", City = "Warszawa", ZipCode = "00-001", Country = "PL" }
        ];
    }

    private static List<SpeechTherapist> CreateSpeechTherapists(List<Admin> admins, List<Address> addresses) {
        return [
            new SpeechTherapist {
                FirstName = "Anna",
                LastName = "Wiśniewska",
                DateOfBirth = new DateTime(1996, 1, 14, 0, 0, 0, DateTimeKind.Utc),
                Contact = new Contact { PhoneNumber = "723341321", Email = "anna.wisniewska@logoapp.test" },
                Address = addresses[0],
                AccountStatus = AccountStatus.Active,
                JoinDate = new DateTime(2026, 11, 3, 14, 21, 4, DateTimeKind.Utc),
                Description = "Logopeda dziecięcy.",
                Links = ["https://example.com/anna-wisniewska", "https://example.com/anna-wisniewska/blog"],
                Admins = [admins[0]]
            },
            new SpeechTherapist {
                FirstName = "Piotr",
                MiddleName = "Jan",
                LastName = "Zieliński",
                DateOfBirth = new DateTime(1982, 9, 14, 0, 0, 0, DateTimeKind.Utc),
                Contact = new Contact { PhoneNumber = "721554210", Email = "piotr.zielinski@logoapp.test" },
                AccountStatus = AccountStatus.Pending,
                JoinDate = new DateTime(2026, 11, 9, 9, 5, 0, DateTimeKind.Utc),
                Description = "Logopeda dorosłych.",
                Admins = [admins[0], admins[1]]
            }
        ];
    }

    private static List<Credential> CreateCredentials(List<SpeechTherapist> speechTherapists) {
        return [
            new Credential {
                DocumentStatus = DocumentStatus.Verified,
                DocumentType = DocumentType.DegreeStudies,
                Document = "%PDF-1.7"u8.ToArray(),
                SpeechTherapist = speechTherapists[0]
            },
            new Credential {
                DocumentStatus = DocumentStatus.Rejected,
                DocumentType = DocumentType.Specialization,
                Document = "%PDF-1.4"u8.ToArray(),
                SpeechTherapist = speechTherapists[1]
            }
        ];
    }

    private static List<Issue> CreateIssues(List<Session> sessions) {
        return [
            new Issue {
                IssueType = IssueType.TooDifficult,
                Description = "Nie potrafię utrzymać języka przy podniebieniu dłużej niż kilka sekund",
                VideoRecording = "\0\0\0\u0018ftypmp42"u8.ToArray(),
                AudioRecording = "ID3"u8.ToArray(),
                IssueStatus = IssueStatus.Closed,
                Response = "Proszę skrócić serię do 15 sekund i stopniowo ją wydłużać",
                Session = sessions[0]
            },
            new Issue {
                IssueType = IssueType.ItHurts,
                Description = "Po ćwiczeniu boli mnie żuchwa",
                IssueStatus = IssueStatus.Pending,
                Session = sessions[2]
            }
        ];
    }

    private static List<Session> CreateSessions(List<TherapyTask> tasks) {
        return [
            new Session { Timestamp = new DateTime(2026, 11, 5, 17, 0, 0, DateTimeKind.Utc), TherapyTask = tasks[0] },
            new Session { Timestamp = new DateTime(2026, 11, 6, 17, 10, 0, DateTimeKind.Utc), TherapyTask = tasks[1] },
            new Session { Timestamp = new DateTime(2026, 11, 7, 16, 45, 0, DateTimeKind.Utc), TherapyTask = tasks[0] }
        ];
    }

    private static List<TherapyStage> CreateTherapyStages() {
        return [
            new TherapyStage {
                StartTime = new DateTime(2026, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2026, 10, 31, 0, 0, 0, DateTimeKind.Utc),
                Description = "Ćwiczenia przygotowujące aparat artykulacyjny.",
                TherapyStageStatus = TherapyStageStatus.Preparation
            },
            new TherapyStage {
                StartTime = new DateTime(2026, 11, 1, 0, 0, 0, DateTimeKind.Utc),
                TherapyStageStatus = TherapyStageStatus.SoundElicitation
            },
            new TherapyStage {
                StartTime = new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2026, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                Description = "Utrwalanie głoski w wyrazach i zdaniach.",
                TherapyStageStatus = TherapyStageStatus.Practice
            },
            new TherapyStage {
                StartTime = new DateTime(2027, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                TherapyStageStatus = TherapyStageStatus.Automation
            }
        ];
    }

    private static List<TherapyPlan> CreateTherapyPlans(
        List<TherapyStage> therapyStages,
        List<Disorder> disorders,
        List<Patient> patients) {
        return [
            new TherapyPlan {
                GoalDescription = "Wywołanie i utrwalenie głoski [r] w mowie spontanicznej.",
                StartTime = new DateTime(2026, 10, 1, 0, 0, 0, DateTimeKind.Utc),
                TherapyStages = [therapyStages[0], therapyStages[1]],
                Disorders = [disorders[0]],
                Patient = patients[0]
            },
            new TherapyPlan {
                GoalDescription = "Wzmocnienie napięcia mięśni warg i poprawa artykulacji głosek wargowych.",
                StartTime = new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2027, 3, 31, 0, 0, 0, DateTimeKind.Utc),
                TherapyStages = [therapyStages[2], therapyStages[3]],
                Disorders = [disorders[1]],
                Patient = patients[1]
            }
        ];
    }

    private static List<Patient> CreatePatients(
        List<Admin> admins,
        List<SpeechTherapist> speechTherapists) {
        return [
            new Patient {
                FirstName = "Jan",
                LastName = "Kowalczyk",
                DateOfBirth = new DateTime(2016, 3, 12, 0, 0, 0, DateTimeKind.Utc),
                Contact = new Contact { PhoneNumber = "601234567", Email = "jan.kowalczyk@logoapp.test" },
                AccountStatus = AccountStatus.Active,
                JoinDate = new DateTime(2026, 11, 4, 10, 15, 0, DateTimeKind.Utc),
                SpeechTherapist = speechTherapists[0],
                Admins = [admins[0]]
            },
            new Patient {
                FirstName = "Zofia",
                MiddleName = "Anna",
                LastName = "Lewandowska",
                DateOfBirth = new DateTime(2018, 7, 3, 0, 0, 0, DateTimeKind.Utc),
                Contact = new Contact { PhoneNumber = "602345678", Email = "zofia.lewandowska@logoapp.test" },
                AccountStatus = AccountStatus.Active,
                JoinDate = new DateTime(2026, 11, 5, 16, 40, 0, DateTimeKind.Utc),
                SpeechTherapist = speechTherapists[0],
                Admins = [admins[1]]
            },
            new Patient {
                FirstName = "Marek",
                LastName = "Wójcik",
                DateOfBirth = new DateTime(1961, 11, 25, 0, 0, 0, DateTimeKind.Utc),
                Contact = new Contact { PhoneNumber = "603456789", Email = "marek.wojcik@logoapp.test" },
                AccountStatus = AccountStatus.Inactive,
                JoinDate = new DateTime(2026, 11, 9, 8, 30, 0, DateTimeKind.Utc),
                Admins = [admins[0]]
            }
        ];
    }

}