using ApiCrudFuncionario.Data;
using ApiCrudFuncionario.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiCrudFuncionario.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly AppDbContext _context;
        public FuncionarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel NovoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (NovoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não pode ser nulo.";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Funcionarios.Add(NovoFuncionario);
                await _context.SaveChangesAsync();
                serviceResponse.Mensagem = "Funcionário criado com sucesso.";

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.ID == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                    return serviceResponse;
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Funcionarios.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Funcionário deletado com sucesso.";

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
                return serviceResponse;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.ID == id);

                serviceResponse.Dados = funcionario;
                serviceResponse.Mensagem = "Funcionário encontrado com sucesso.";

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                }
             

            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Funcionários encontrados com sucesso.";

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum funcionário encontrado.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse; 
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
               FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.ID == id);
                 

                if (funcionario == null)
                {
                    {   serviceResponse.Dados = null;
                        serviceResponse.Sucesso = false;
                        serviceResponse.Mensagem = "Funcionário não encontrado.";
                        return serviceResponse;
                    }
                }
                funcionario.Ativo = false;
                funcionario.DataDeAtualizacao = DateTime.Now.ToLocalTime();
                serviceResponse.Mensagem = "Funcionário editado com sucesso.";
                serviceResponse.Sucesso = true;

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel EditadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {

                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(f => f.ID == EditadoFuncionario.ID);
                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Funcionário não encontrado.";
                    return serviceResponse;
                }

                funcionario.DataDeAtualizacao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(EditadoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Funcionário editado com sucesso.";



            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }
            return serviceResponse;
        }
    }
}
