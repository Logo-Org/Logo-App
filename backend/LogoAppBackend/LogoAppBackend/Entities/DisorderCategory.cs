using System.ComponentModel;

namespace LogoAppBackend.Entities;

public enum DisorderCategory {

    [Description("Sygmatyzm")]
    Sigmatism,

    [Description("Rotacyzm")]
    Rhotacism,

    [Description("Lambdacyzm")]
    Lambdacism,

    [Description("Kappacyzm")]
    Kappacism,

    [Description("Ubezdźwięcznienie")]
    Devoicing,

    [Description("Nosowanie")]
    Rhinolalia

}