using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class HouseSeeder
    {
        public static List<House> GetHouses()
        {
            return new List<House>
            {
                new House
                {
                    Id = "house_Atreides",
                    Name = "House Atreides",
                    ShortDescription = "A Great House renowned for its honor, beloved by its subjects, and betrayed by the Imperium it served.",
                    DetailedHistory = "Ruling Caladan for twenty-six generations, House Atreides rose to prominence under Duke Leto before accepting the Emperor's fief on Arrakis - a trap that led to its near-annihilation and, ultimately, Paul Atreides' ascent to the Golden Lion Throne.",
                    ImagePath = "images/houses/atreides.jpg",
                    RelatedEntityIds = new List<string> { "loc_Caladan", "loc_Arrakis", "char_DukeLetoAtreides", "char_PaulAtreides", "char_LadyJessica", "char_DukePaulusAtreides", "char_VorianAtreides", "event_DeathOfDukePaulus" },
                    Sigil = "A red hawk",
                    Motto = "The sleeper must awaken",
                    HistoricalRivalries = new List<string> { "house_Harkonnen" }
                },
                new House
                {
                    Id = "house_Harkonnen",
                    Name = "House Harkonnen",
                    ShortDescription = "A Great House defined by cruelty, cunning, and an ancient blood-feud with House Atreides.",
                    DetailedHistory = "Ruling from the industrial squalor of Giedi Prime, House Harkonnen orchestrated the fall of House Atreides on Arrakis with covert Imperial backing, only to be undone by the son of the Duke it betrayed.",
                    ImagePath = "images/houses/harkonnen.jpg",
                    RelatedEntityIds = new List<string> { "loc_GiediPrime", "char_BaronHarkonnen", "char_FeydRautha", "char_GlossuRabban", "char_AbulurdHarkonnen", "char_XavierHarkonnen", "loc_Lankiveil" },
                    Sigil = "A griffin",
                    Motto = "Plans within plans within plans",
                    HistoricalRivalries = new List<string> { "house_Atreides" }
                },
                new House
                {
                    Id = "house_Corrino",
                    Name = "House Corrino",
                    ShortDescription = "The Imperial House that has held the Golden Lion Throne for ten millennia.",
                    DetailedHistory = "Ruling from Kaitain, House Corrino maintained Imperial power through a careful balance between the Landsraad, CHOAM, and their own terrifying Sardaukar legions, until Shaddam IV's gambit on Arrakis cost them the throne.",
                    ImagePath = "images/houses/corrino.jpg",
                    RelatedEntityIds = new List<string> { "loc_Kaitain", "loc_SalusaSecundus", "char_ShaddamIV", "char_PrincessIrulan", "org_Sardaukar", "char_ElroodIX" },
                    Sigil = "The golden lion",
                    Motto = "By right of the Golden Lion Throne",
                    HistoricalRivalries = new List<string> { "house_Atreides" }
                },
                new House
                {
                    Id = "house_Ecaz",
                    Name = "House Ecaz",
                    ShortDescription = "A Great House celebrated for its master woodcarvers, long feuding with House Moritani.",
                    DetailedHistory = "Known throughout the Imperium for artistry rather than arms, House Ecaz's generations-long blood feud with House Moritani of Grumman drew in the Atreides during the reign of Paul's children.",
                    ImagePath = "images/houses/ecaz.jpg",
                    RelatedEntityIds = new List<string> { "loc_Ecaz", "house_Moritani" },
                    Sigil = "A carved wooden emblem",
                    Motto = "Artistry endures where arms fail",
                    HistoricalRivalries = new List<string> { "house_Moritani" }
                },
                new House
                {
                    Id = "house_Moritani",
                    Name = "House Moritani",
                    ShortDescription = "The volatile ruling House of Grumman, bitter rivals of House Ecaz.",
                    DetailedHistory = "Known for a violent temper and a willingness to skirt the Great Convention, House Moritani's feud with House Ecaz became one of the most dangerous Landsraad disputes of its era.",
                    ImagePath = "images/houses/moritani.jpg",
                    RelatedEntityIds = new List<string> { "house_Ecaz" },
                    Sigil = "Not widely recorded outside Grumman",
                    Motto = "Not widely recorded outside Grumman",
                    HistoricalRivalries = new List<string> { "house_Ecaz" }
                },
                new House
                {
                    Id = "house_Richese",
                    Name = "House Richese",
                    ShortDescription = "A Great House whose fortune rests on miniaturized technology and clever devices.",
                    DetailedHistory = "A perennial commercial and technological rival to Ix, House Richese trades in intricate gadgets, probes, and mechanisms that push against the boundaries set by the Butlerian Jihad.",
                    ImagePath = "images/houses/richese.jpg",
                    RelatedEntityIds = new List<string> { "loc_Ix", "theo_ButlerianDoctrine", "loc_Richese" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string> { "house_Vernius" }
                },
                new House
                {
                    Id = "house_Vernius",
                    Name = "House Vernius",
                    ShortDescription = "The ruling House of the technological world Ix.",
                    DetailedHistory = "Governing the subterranean machine-city of Ix, House Vernius walks a careful line between innovation and the Butlerian taboo against thinking machines, its fortunes tightly bound to the secrets it manufactures.",
                    ImagePath = "images/houses/vernius.jpg",
                    RelatedEntityIds = new List<string> { "loc_Ix", "house_Richese", "char_DominicVernius", "char_RhomburVernius", "event_IxianCoup" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string> { "house_Richese" }
                },
                new House
                {
                    Id = "house_Fenring",
                    Name = "House Fenring",
                    ShortDescription = "A minor but influential House built around the Emperor's closest confidant, Count Hasimir Fenring.",
                    DetailedHistory = "Though it never rose to Great House status, House Fenring wielded outsized influence through Count Fenring's role as Shaddam IV's most trusted friend, spy, and occasional executioner.",
                    ImagePath = "images/houses/fenring.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino", "char_ShaddamIV", "org_BeneGesserit", "char_HasimirFenring", "char_MargotFenring" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string>()
                },
                new House
                {
                    Id = "house_Wayku",
                    Name = "House Wayku",
                    ShortDescription = "A minor House once entrusted with guarding the Atreides ancestral crypts on Caladan.",
                    DetailedHistory = "Tasked for generations with the honor of maintaining House Atreides' burial grounds, House Wayku's loyalty frayed over time, leaving behind a cautionary tale about trust within the Landsraad.",
                    ImagePath = "images/houses/wayku.jpg",
                    RelatedEntityIds = new List<string> { "house_Atreides", "loc_Caladan" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string> { "house_Atreides" }
                },
                new House
                {
                    Id = "house_Tuek",
                    Name = "House Tuek",
                    ShortDescription = "A smuggling dynasty operating outside official Landsraad recognition, based on Arrakis.",
                    DetailedHistory = "Led by figures such as Esmar and Staban Tuek, this smuggling house maintained hidden bases beyond Imperial and Harkonnen control, quietly trading spice and sheltering fugitives like Gurney Halleck after the fall of House Atreides.",
                    ImagePath = "images/houses/tuek.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis", "char_GurneyHalleck" },
                    Sigil = "Not widely recorded",
                    Motto = "Not widely recorded",
                    HistoricalRivalries = new List<string>()
                }
            };
        }
    }
}
