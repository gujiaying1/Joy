namespace JoyRiseFitness.Models
{
    public class User
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }   // 明文演示，作业可接受
    }
}