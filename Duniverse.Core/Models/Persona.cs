using System.Collections.Generic;

namespace Duniverse.Models
{
    /// <summary>
    /// Represents a central figure or character in the universe.
    /// </summary>
    public class Persona : DuneEntity
    {
        /// <summary>
        /// The faction or house the character belongs to, written for a reader. This is the line
        /// the record shows, so it keeps the nuance a roster can't hold ("Fremen (secretly House
        /// Corrino)", "Honored Matres (later Bene Gesserit)").
        /// </summary>
        public string? Affiliation { get; set; }

        /// <summary>
        /// The IDs of the houses and organizations this character actually belongs to. This is
        /// what a house or order's Known Members roster is built from, and it exists because the
        /// prose above can't be matched on reliably: a display name is a substring of another
        /// one often enough ("Fremen" sits inside "Museum Fremen") that name matching quietly
        /// puts people on rosters they were never on, and a member whose affiliation reads
        /// "House Corrino" never turns up on his own House Fenring roster at all.
        ///
        /// More than one ID is normal rather than an edge case. Plenty of figures genuinely
        /// serve two masters, and the truthful answer is to list them under both.
        ///
        /// The test for belonging is who the house or order counts as its own, not blood and
        /// name. Sworn retainers pass it: Duncan, Gurney and Thufir all sit on the Atreides
        /// roster. Being attached to a House without ever being bound to it does not, which is
        /// why Jessica and Chani do not, close as both of them were to it.
        ///
        /// The Landsraad and CHOAM are left off deliberately, so their empty rosters are the
        /// intended answer rather than a gap waiting to be filled. Seats and directorships in
        /// both belong to Houses, not to people, and nobody in the saga is a member of either
        /// the way a man is Atreides or a sister is Bene Gesserit.
        /// </summary>
        public List<string> AffiliationIds { get; set; } = new List<string>();

        /// <summary>
        /// The character's primary role or title (e.g., Mentat, Reverend Mother).
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// A collection of memorable quotes attributed to the character.
        /// </summary>
        public List<string> NotableQuotes { get; set; } = new List<string>();
    }
}