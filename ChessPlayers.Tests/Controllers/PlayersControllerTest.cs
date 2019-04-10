using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessPlayers;
using ChessPlayers.Controllers;
using ChessPlayers.Models;


namespace ChessPlayers.Tests.Controllers
{
    [TestClass]
    public class PlayersControllerTest
    {

        [TestMethod]
        public void TestIndexView()
        {
            PlayersController controller = new PlayersController();
            ViewResult result = controller.Index("") as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestDetailsView()
        {
            PlayersController controller = new PlayersController();
            ViewResult result = controller.Details(1) as ViewResult;
            var player = (Player)result.Model;
            Assert.AreEqual("Fabiano", player.Name);
        }

        [TestMethod]
        public void TestAddView()
        {
            PlayersController controller = new PlayersController();
            ViewResult result = controller.Add() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void TestEditView()
        {
            PlayersController controller = new PlayersController();
            ViewResult result = controller.Edit(1) as ViewResult;
            var player = (Player)result.Model;
            Assert.AreEqual("Fabiano", player.Name);
        }

        [TestMethod]
        public void TestDeleteView()
        {
            PlayersController controller = new PlayersController();
            ViewResult result = controller.Delete(1) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void TestDeleteConfirmed()
        {
            PlayersController controller = new PlayersController();
            var result = (RedirectToRouteResult)controller.DeleteConfirmed(2);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        
    }
}