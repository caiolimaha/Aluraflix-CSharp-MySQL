using Aluraflix.Data.Dtos;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aluraflix.Services
{
    public interface IVideoService
    {
        Task<ReadVideoDto> AdicionaVideo(CreateVideoDto videoDto);
        Task<ReadVideoDto> RecuperaVideoPorId(int id);
        Task<Result> AtualizaVideo(int id, UpdateVideoDto videoDto);
        Task<List<ReadVideoDto>> RecuperaVideoPorTitulo(string nomeDoVideo);
        Task<Result> DeletaVideo(int id);
    }
}
