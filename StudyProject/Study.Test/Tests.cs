using System;
using System.Linq;
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
            var groupTeamMethods = new GroupTeamMethods();
            // crio o objeto de grupo
            var groupTeam = new GroupTeamDTO
            {
                Name = "Test Name",
                CreateDate = DateTime.Now,
                Description = "Testing the description"
            };

            // vejo quantos items da tabela grupo tinham antes
            int totalBefore = groupTeamMethods.Display().Count;

            // crio no grupo passando o objeto que criei
            groupTeamMethods.Create(groupTeam);

            // vejo quantos items tem na tabela depois
            int totalAfter = groupTeamMethods.Display().Count;

            // verifico se o total antes+1 é o mesmo que o total depois
            // se for, significa que foi criado
            Assert.IsTrue((totalBefore) + 1 == totalAfter);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var update = new GroupTeamMethods();
            // crio o objeto de grupo para atualizar
            var groupTeam = new GroupTeamDTO
            {
                Name = "HUE BR",
                Description = "FESTA"
            };

            var lastItemOfTheList = update.Display().LastOrDefault().GroupTeamId;

            // atualizo na tabela passando o item que quero modificar
            // e o objeto que modifiquei
            update.Update(lastItemOfTheList, groupTeam);

            // guardo o objeto que atualizei
            var responseFind = update.Find(lastItemOfTheList);

            // verifico se o item que criei possui a o mesmo nome do objeto que mandei
            // se sim, significa que o update está ok
            Assert.IsTrue(responseFind.Name == groupTeam.Name);
        }

        [TestMethod]
        public void TestDelete()
        {
            var groupTeamMethods = new GroupTeamMethods();

            var lastItemOfTheList = groupTeamMethods.Display().LastOrDefault().GroupTeamId;
            // deleto o item que quero
            groupTeamMethods.Delete(lastItemOfTheList);

            // tento encontrar o item que deletei
            var responseFind = groupTeamMethods.Find(lastItemOfTheList);

            // se for nulo, significa que o item foi apagado e o método funciona
            Assert.IsNull(responseFind);
        }

        [TestMethod]
        public void TestList()
        {
            var groupTeamMethods = new GroupTeamMethods();
            // vejo se a lista da tabela não está nula
            // se não estiver, é porque o display está funcionando
            var listTest = groupTeamMethods.Display();
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
        public void TestCreateUser()
        {
            var groupTeamMethods = new GroupTeamMethods();
            var userTeamMethods = new UserTeamMethods();
            // crio o objeto que irei enviar para o método de criar user
            var userObject = new UserTeamDTO
            {
                CreateDate = DateTime.Now,
                FullName = "123 de Oliveira 4",
                GroupTeamId = groupTeamMethods.Display().LastOrDefault().GroupTeamId,
                IsEnabled = true,
                Login = "testlogin",
                Password = "m@hPswd123"
            };

            // guardo quantos users tinham antes de eu criar o novo user
            int usersBefore = userTeamMethods.Display().Count;

            // crio o novo user
            userTeamMethods.Create(userObject);

            // guardo quantos users tem depois
            int usersAfter = userTeamMethods.Display().Count;

            // verifico se a quantidade de users antes + 1 é igual a quantidade de users agora
            // se sim, foi criado direitinho
            Assert.IsTrue((usersBefore) + 1 == usersAfter);
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            var userTeamMethods = new UserTeamMethods();
            var lastItemOfTheList = userTeamMethods.Display().LastOrDefault().UserTeamId;
            // Crio objeto com itens que vou modificar
            var userObject = new UserTeamDTO
            {
                FullName = "Policial Saraiva",
                GroupTeamId = 3,
                IsEnabled = false,
                Password = "esqueciminhasenha"
            };

            // Faço o update, indicando qual item da tabela será modificado
            userTeamMethods.Update(lastItemOfTheList, userObject);

            // Guardo na variável o suposto usuário modificado,
            var modifiedUser = userTeamMethods.Find(lastItemOfTheList);

            // então verifico se alum item do meu objeto modificado está igual ao que está na base
            Assert.IsTrue(userObject.FullName == modifiedUser.FullName);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            var userTeamMethods = new UserTeamMethods();
            var lastItemOfTheList = userTeamMethods.Display().LastOrDefault().UserTeamId;
            // Deleta o item e depois verifica se o id do user está nulo
            // estando nulo, significa que foi deletado.
            userTeamMethods.Delete(lastItemOfTheList);
            Assert.IsNull(userTeamMethods.Find(lastItemOfTheList));
        }

        [TestMethod]
        public void TestDisplay()
        {
            var userTeamMethods = new UserTeamMethods();
            // Verifica se a lista não retorna nula
            Assert.IsNotNull(userTeamMethods.Display());
        }
    }
    #endregion
}
