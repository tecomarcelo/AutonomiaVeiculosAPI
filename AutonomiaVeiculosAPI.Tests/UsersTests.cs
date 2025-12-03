using AutonomiaVeiculosAPI.Application.Dtos.Requests;
using AutonomiaVeiculosAPI.Application.Dtos.Responses;
using AutonomiaVeiculosAPI.Tests.Helper;
using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Tests
{
    public class UsersTests
    {
        [Fact]
        public async Task Users_Post_Returns_Create()
        {
            //dados enviados para a requisição
            var faker = new Faker("pt_BR");

            var request = new UserAddRequestDto
            {
                Name = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Password = "@Testes123",
                PasswordConfirm = "@Testes123",
            };

            //serializando os dados da requisição
            var content = TestHelper.CreateContent(request);

            //fazendo a requisição POST para a API
            var result = await TestHelper.CreateClient.PostAsync("/api/users", content);

            //capturando e verificando o status de resposta
            result.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            //capturando e verificando o conteudo da resposta
            var response = TestHelper.ReadResponse<UserResponseDto>(result);
            response.Id.Should().NotBeEmpty();
            response.Name.Should().Be(request.Name);
            response.Email.Should().Be(request.Email);
            response.CreatedAt.Should().NotBeNull();
        }
        [Fact(Skip = "não implementado.")]
        public void Users_Put_Returns_BadRequest()
        {
            //TODO
        }

        [Fact(Skip = "não implementado.")]
        public void Users_Delete_Returns_BadRequest()
        {
            //TODO
        }

        [Fact(Skip = "não implementado.")]
        public void Users_Get_Returns_BadRequest()
        {
            //TODO
        }
    }
}
