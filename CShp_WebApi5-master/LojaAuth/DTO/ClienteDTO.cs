﻿using System.ComponentModel.DataAnnotations;


namespace LojaAuth.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int EnderecoId { get; set; }

        [Required]
        public EnderecoDTO Endereco { get; set; }
    }
}
