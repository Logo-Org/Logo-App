using LogoAppBackend.Entities;

using Task = System.Threading.Tasks.Task;

namespace LogoAppBackend.Data;

public class DemoDataSeeder(AppDbContext database) {

    public async Task SeedAsync() {
        database.Admin.AddRange(CreateAdmins());
        await database.SaveChangesAsync();
    }

    private static List<Admin> CreateAdmins() => [
        new() {
            FirstName = "Kamil",
            LastName = "Kowalski",
            DateOfBirth = new DateTime(1987, 1, 22, 0, 0, 0, DateTimeKind.Utc),
            Contact = new Contact { PhoneNumber = "+48534102110", Email = "kamil@logoapp.test" }
        },
        new() {
            FirstName = "Ewa",
            MiddleName = "Maria",
            LastName = "Nowak",
            DateOfBirth = new DateTime(1992, 3, 8, 0, 0, 0, DateTimeKind.Utc),
            Contact = new Contact { PhoneNumber = "+48533241229", Email = "ewa.kowalczyk@logoapp.test" }
        }
    ];

}