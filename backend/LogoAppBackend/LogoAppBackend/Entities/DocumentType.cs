using System.ComponentModel;

namespace LogoAppBackend.Entities;

public enum DocumentType {

    [Description("Dyplom ukończenia studiów")]
    DegreeStudies,

    [Description("Świadectwo ukończenia studiów podyplomowych")]
    PostgraduateStudies,

    [Description("Dyplom uzyskania tytułu specjalisty")]
    Specialization

}