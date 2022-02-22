using Aluraflix.Data.Dtos;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aluraflix.Services
{
    public interface IVideoService
    {
        public Task<ReadVideoDto> AdicionaVideo(CreateVideoDto videoDto);
        public Task<ReadVideoDto> RecuperaVideoPorId(int id);
        public Task<Result> AtualizaVideo(int id, UpdateVideoDto videoDto);
        public Task<List<ReadVideoDto>> RecuperaVideoPorTitulo(string nomeDoVideo);
        public Task<Result> DeletaVideo(int id);
    }
}
