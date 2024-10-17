using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Models
{

    [PrimaryKey(nameof(SeminarId), nameof(ParticipantId))]
    public class SeminarParticipant
    {
        [Required]
        public int SeminarId { get; set; }

        [Required]
        [ForeignKey(nameof(SeminarId))]
        public Seminar Seminar { get; set; } = null!;

        [Required]
        public string ParticipantId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ParticipantId))]
        public IdentityUser Participant { get; set; } = null!;
    }
}
//•	Has SeminarId – integer, PrimaryKey, foreign key (required)
//•	Has Seminar – Seminar
//•	Has ParticipantId – string, PrimaryKey, foreign key (required)
//•	Has Participant – IdentityUser
