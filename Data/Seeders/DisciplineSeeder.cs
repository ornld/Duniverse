using System.Collections.Generic;
using Duniverse.Models;

namespace Duniverse.Data.Seeders
{
    public static class DisciplineSeeder
    {
        public static List<Discipline> GetDisciplines()
        {
            return new List<Discipline>
            {
                new Discipline
                {
                    Id = "disc_BeneGesseritTraining",
                    Name = "Bene Gesserit Way",
                    ShortDescription = "Mental and physical conditioning for total bodily control.",
                    DetailedHistory = "Developed over millennia, this training allows practitioners to control their own metabolism, detect truth through tone, and perform the deadly Weirding Way.",
                    ImagePath = "images/disciplines/bg_training.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_LadyJessica", "char_PaulAtreides" },
                    Requirements = "Genetic predisposition, years of rigorous mental conditioning",
                    Mechanics = "Prana-bindu awareness, Voice modulation, Truth-sense"
                },
                new Discipline
                {
                    Id = "disc_Mentat",
                    Name = "Mentat",
                    ShortDescription = "Human computer logic and analytical processing.",
                    DetailedHistory = "Formed to replace thinking machines after the Butlerian Jihad, Mentats are trained to synthesize vast data points into precise strategic predictions.",
                    ImagePath = "images/disciplines/mentat_training.jpg",
                    RelatedEntityIds = new List<string> { "char_ThufirHawat", "char_PiterDeVries" },
                    Requirements = "Exceptional intellect, focus training",
                    Mechanics = "Super-logic, data synthesis, probability calculation"
                },
                new Discipline
                {
                    Id = "disc_WeirdingWay",
                    Name = "Weirding Way",
                    ShortDescription = "A martial art based on extreme speed and muscle control.",
                    DetailedHistory = "Often misinterpreted by outsiders as magic, it is the application of prana-bindu training to physical combat, moving faster than the eye can track.",
                    ImagePath = "images/disciplines/weirding_way.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "org_Fremen", "char_PaulAtreides" },
                    Requirements = "Prana-bindu mastery",
                    Mechanics = "High-speed strikes, kinetic redirection"
                },
                new Discipline
                {
                    Id = "disc_FremenDesertSurvival",
                    Name = "Desert Survival",
                    ShortDescription = "Expertise in adapting to the harsh conditions of Arrakis.",
                    DetailedHistory = "The distillation of centuries of experience on Arrakis, allowing a person to thrive where others die in hours.",
                    ImagePath = "images/disciplines/survival.jpg",
                    RelatedEntityIds = new List<string> { "org_Fremen", "loc_Arrakis" },
                    Requirements = "Total reliance on recycled moisture",
                    Mechanics = "Water discipline, sand-walking, worm-riding"
                },
                new Discipline
                {
                    Id = "disc_SpiceMining",
                    Name = "Spice Mining",
                    ShortDescription = "Industrial extraction of the melange.",
                    DetailedHistory = "A hazardous profession requiring complex coordination between crawler operations, spotter planes, and ornithopter escorts.",
                    ImagePath = "images/disciplines/mining.jpg",
                    RelatedEntityIds = new List<string> { "loc_Arrakis" },
                    Requirements = "Technical aptitude, courage against worms",
                    Mechanics = "Heavy vehicle operation, hazard detection"
                },
                new Discipline
                {
                    Id = "disc_GuildNavigation",
                    Name = "Guild Navigation",
                    ShortDescription = "Prescient navigation through folded space.",
                    DetailedHistory = "Navigators consume high quantities of spice to achieve limited prescience, enabling safe travel between stars.",
                    ImagePath = "images/disciplines/navigation.jpg",
                    RelatedEntityIds = new List<string> { "org_SpacingGuild" },
                    Requirements = "High spice tolerance, genetic mutation",
                    Mechanics = "Prescient path-finding, space folding"
                },
                new Discipline
                {
                    Id = "disc_SukMedical",
                    Name = "Suk Medical Conditioning",
                    ShortDescription = "The pinnacle of medical knowledge, made trustworthy by conditioning.",
                    DetailedHistory = "Doctors are marked by a diamond tattoo. They are conditioned to be incapable of taking a human life, supposedly guaranteeing total loyalty.",
                    ImagePath = "images/disciplines/suk_med.jpg",
                    RelatedEntityIds = new List<string> { "char_WellingtonYueh" },
                    Requirements = "Imperial medical degree, intensive psychological conditioning",
                    Mechanics = "Advanced surgery, bio-toxin analysis"
                },
                new Discipline
                {
                    Id = "disc_SardaukarWarfare",
                    Name = "Sardaukar Training",
                    ShortDescription = "Brutal combat training from the prison planet Salusa Secundus.",
                    DetailedHistory = "Ensures the Emperor’s elite soldiers are unmatched in individual combat, possessing extreme physical strength and ruthlessness.",
                    ImagePath = "images/disciplines/sardaukar.jpg",
                    RelatedEntityIds = new List<string> { "house_Corrino" },
                    Requirements = "Survival on Salusa Secundus, peak physical conditioning",
                    Mechanics = "Terror-tactics, lethal efficiency"
                },
                new Discipline
                {
                    Id = "disc_SwordmasterGinaz",
                    Name = "Ginaz Swordmastery",
                    ShortDescription = "The highest standard of blade-fighting technique.",
                    DetailedHistory = "The Swordmasters of Ginaz were once the preeminent trainers of house guards, valuing speed, elegance, and precision over brute force.",
                    ImagePath = "images/disciplines/ginaz_blade.jpg",
                    RelatedEntityIds = new List<string> { "char_DuncanIdaho" },
                    Requirements = "Years of master-apprentice dueling",
                    Mechanics = "Blade precision, defensive reflexes"
                },
                new Discipline
                {
                    Id = "disc_KwisatzHaderachProcess",
                    Name = "Kwisatz Haderach Breeding",
                    ShortDescription = "The Bene Gesserit's secret multi-generational genetic project.",
                    DetailedHistory = "A long-term project designed to produce a male capable of accessing both male and female ancestral memories and seeing through space and time.",
                    ImagePath = "images/disciplines/breeding.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneGesserit", "char_PaulAtreides", "char_HasimirFenring" },
                    Requirements = "Strict lineage control, genetic manipulation",
                    Mechanics = "Genetic synthesis, prescient awakening"
                },
                new Discipline
                {
                    Id = "disc_HonoredMatreImprinting",
                    Name = "Honored Matre Imprinting",
                    ShortDescription = "A sexual-conditioning technique the Honored Matres use to bind men in absolute loyalty.",
                    DetailedHistory = "Distinct from - and cruder than - the Bene Gesserit's own subtleties, Honored Matre imprinting creates an inescapable devotion in its subjects, a tool of conquest that the Sisterhood found both abhorrent and, eventually, worth partially adopting.",
                    ImagePath = "images/disciplines/honored_matre_imprinting.jpg",
                    RelatedEntityIds = new List<string> { "org_HonoredMatres", "char_Murbella", "org_BeneGesserit" },
                    Requirements = "Training within the Honored Matre order; willingness to use intimacy as a weapon",
                    Mechanics = "Neurological/hormonal conditioning delivered through sexual contact"
                },
                new Discipline
                {
                    Id = "disc_GholaCultivation",
                    Name = "Ghola Cultivation",
                    ShortDescription = "The Tleilaxu practice of regrowing the dead from preserved cellular material.",
                    DetailedHistory = "Using axlotl tanks, the Tleilaxu can regrow a deceased person's body from a cell sample, producing a ghola who can - under the right conditions - recover the original's memories and identity, a process that returned Duncan Idaho to service again and again across the centuries.",
                    ImagePath = "images/disciplines/ghola_cultivation.jpg",
                    RelatedEntityIds = new List<string> { "org_BeneTleilax", "char_DuncanIdaho", "char_MilesTeg", "char_Scytale" },
                    Requirements = "A viable cell sample from the deceased; Tleilaxu axlotl tank technology",
                    Mechanics = "Cellular regrowth followed by a triggering process to recover original memories"
                }
            };
        }
    }
}