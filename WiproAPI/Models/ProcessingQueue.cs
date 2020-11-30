using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WiproAPI.Models
{
	public class ProcessingQueue
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required(ErrorMessage = "This field is required.")]
		public string Moeda { get; set; }
		[Required(ErrorMessage = "This field is required.")]
		public string Data_Inicio { get; set; }
		[Required(ErrorMessage = "This field is required.")]
		public string Data_Fim { get; set; }
		public bool Ativo { get; set; } = true;
		public string Data_Criacao { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
	}
}
