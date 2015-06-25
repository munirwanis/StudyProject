using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Study.Business;
using Study.Business.DTO;
using Study.Entity;

namespace Study.Test
{
    #region Testes da Tabela Group
    /// <summary>
    /// Classe para testes nos métodos do GroupTeam
    /// </summary>
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void TestCreateGroup()
        {
            // crio o objeto de grupo
            var groupTeam = new GroupTeamDTO { 
            Name = "Test Name",
            CreateDate = DateTime.Now,
            Description = "Testing the description"
            };

            // vejo quantos items da tabela grupo tinham antes
            int totalBefore = GroupTeamMethods.Display().Count;

            // crio no grupo passando o objeto que criei
            GroupTeamMethods.Create(groupTeam);

            // vejo quantos items tem na tabela depois
            int totalAfter = GroupTeamMethods.Display().Count;

            // verifico se o total antes+1 é o mesmo que o total depois
            // se for, significa que foi criado
            Assert.IsTrue((totalBefore) + 1 == totalAfter);
        }

        [TestMethod]
        public void TestUpdate()
        {
            // crio o objeto de grupo para atualizar
            var groupTeam = new GroupTeamDTO
            {
                Name = "HUE BR",
                Description = "FESTA"
            };

            /// atualizo na tabela passando o item que quero modificar
            /// e o objeto que modifiquei
            GroupTeamMethods.Update(1, groupTeam);

            // guardo o objeto que atualizei
            var responseFind = new GroupTeamTable();
            responseFind = GroupTeamMethods.Find(1);

            // verifico se o item que criei possui a o mesmo nome do objeto que mandei
            // se sim, significa que o update está ok
            Assert.IsTrue(responseFind.Name == groupTeam.Name);
        }

        [TestMethod]
        public void TestDelete()
        {
            // deleto o item que quero
            GroupTeamMethods.Delete(2);

            // tento encontrar o item que deletei
            var responseFind = GroupTeamMethods.Find(2);

            // se for nulo, significa que o item foi apagado e o método funciona
            Assert.IsNull(responseFind);
        }

        [TestMethod]
        public void TestList()
        {
            /// vejo se a lista da tabela não está nula
            /// se não estiver, é porque o display está funcionando
            var listTest = GroupTeamMethods.Display();
            Assert.IsNotNull(listTest);
        }
    }
    #endregion

    #region Testes da Tabela User
    /// <summary>
    /// Classe de testes para a tabela de usuários
    /// </summary>
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestCreatUser()
        {
            // crio o objeto que irei enviar para o método de criar user
            var userObject = new UserTeamDTO { 
                CreateDate = DateTime.Now,
                FullName = "123 de Oliveira 4",
                GroupTeamId = 1,
                IsEnabled = true,
                Login = "testlogin",
                Password = "m@hPswd123"
            };

            // guardo quantos users tinham antes de eu criar o novo user
            int usersBefore = UserTeamMethods.Display().Count;

            // crio o novo user
            UserTeamMethods.Create(userObject);

            // guardo quantos users tem depois
            int usersAfter = UserTeamMethods.Display().Count;

            // verifico se a quantidade de users antes + 1 é igual a quantidade de users agora
            // se sim, foi criado direitinho
            Assert.IsTrue((usersBefore) + 1 == usersAfter);
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            // Crio objeto com itens que vou modificar
            var userObject = new UserTeamDTO
            {
                FullName = "Policial Saraiva",
                GroupTeamId = 3,
                IsEnabled = false,
                Password = "esqueciminhasenha"
            };

            // Faço o update, indicando qual item da tabela será modificado
            UserTeamMethods.Update(1, userObject);

            // Guardo na variável o suposto usuário modificado,
            var modifiedUser = UserTeamMethods.Find(1);

            // então verifico se alum item do meu objeto modificado está igual ao que está na base
            Assert.IsTrue(userObject.FullName == modifiedUser.FullName);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            /// Deleta o item e depois verifica se o id do user está nulo
            /// estando nulo, significa que foi deletado.
            UserTeamMethods.Delete(1);
            Assert.IsNull(UserTeamMethods.Find(1));
        }

        [TestMethod]
        public void TestDisplay()
        {
            // Verifica se a lista não retorna nula
            Assert.IsNotNull(UserTeamMethods.Display());
        }
    }
    #endregion
}
