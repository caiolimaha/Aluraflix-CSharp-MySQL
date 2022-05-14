using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private RoleManager<IdentityRole<int>> _roleManager;


        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);
            var createRoleResult = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;
            var usuarioRoleResult = _userManager.AddToRoleAsync(usuarioIdentity, "admin").Result;
            if (resultadoIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário"); 
        }

        public Result AtivaContaRequest(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao);
            if (identityResult.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuario!");

        }
    }
}