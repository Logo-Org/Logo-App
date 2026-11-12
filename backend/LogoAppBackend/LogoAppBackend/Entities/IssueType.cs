using System.ComponentModel;

namespace LogoAppBackend.Entities;

public enum IssueType {

    [Description("Ćwiczenie jest za trudne")]
    TooDifficult,

    [Description("Ćwiczenie sprawia ból")]
    ItHurts,

    [Description("Nie wiem, czy dobrze wykonuję ćwiczenie")]
    UnsureIfCorrect,

    [Description("Instrukcja jest niezrozumiała")]
    UnclearInstructions,

    [Description("Inne")]
    Other

}