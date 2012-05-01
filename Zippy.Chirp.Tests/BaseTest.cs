using System;
using System.Runtime.InteropServices;
using Castle.DynamicProxy.Generators;
using EnvDTE;
using EnvDTE80;
using Extensibility;

namespace Zippy.Chirp.Tests
{
	public abstract class BaseTest
	{
			internal Zippy.Chirp.Chirp chirp;

		DTE2 app;
		TaskList tasks;

		public BaseTest()
		{
			AttributesToAvoidReplicating.Add<TypeIdentifierAttribute>();
			chirp = new Chirp();

			app = GetApp();

			Array arr = null;
			chirp.OnConnection(app, ext_ConnectMode.ext_cm_AfterStartup, QuickMock<AddIn>(), ref  arr);
			tasks = new TaskList(app);
		}

		private static DTE2 GetApp() {
			var mockApp = new Moq.Mock<DTE2>();
			var mockEvents = new Moq.Mock<Events2>();
			mockEvents.Setup(x => x.get_DocumentEvents(null)).Returns(QuickMock<DocumentEvents>());
			mockEvents.Setup(x => x.ProjectItemsEvents).Returns(QuickMock<ProjectItemsEvents>());
			mockEvents.Setup(x => x.SolutionEvents).Returns(QuickMock<SolutionEvents>());
			mockEvents.Setup(x => x.BuildEvents).Returns(QuickMock<BuildEvents>());
			mockEvents.Setup(x => x.get_CommandEvents("{" + Guid.Empty.ToString() + "}", 0)).Returns(QuickMock<CommandEvents>());

			mockApp.Setup(x => x.Events).Returns(() => mockEvents.Object);
			return mockApp.Object;
		}

		private static T QuickMock<T>() where T : class {
			var mock = new Moq.Mock<T>();
			return mock.Object;
		}

		internal string TestEngine<T>(string filename, string code) where T : Zippy.Chirp.Engines.TransformEngine, new()
		{
			var engine = new T();
			var item = GetProjectItem(filename);
			return engine.Transform(filename, code, item);
		}

		internal void TestActionEngine<T>(string filename, string code) where T : Zippy.Chirp.Engines.ActionEngine, new()
		{
			var engine = new T();
			var item = GetProjectItem(filename);
			engine.Run(filename, item);
		}

		internal Project GetProject()
		{
			var moq = new Moq.Mock<Project>();
			return moq.Object;
		}

		internal ProjectItems GetProjectItems()
		{
			var moq = new Moq.Mock<ProjectItems>();
			moq.Setup(x => x.Parent).Returns(() => GetProjectItem("C:\\parentitem.cs"));
			return moq.Object;
		}

		internal ProjectItem GetProjectItem(string filename)
		{
			var moq = new Moq.Mock<ProjectItem>();
			moq.Setup(x => x.get_FileNames(1)).Returns(filename);
			moq.Setup(x => x.Name).Returns(filename);
			moq.Setup(x => x.ContainingProject).Returns(GetProject);
			moq.Setup(x => x.Collection).Returns(GetProjectItems);
			return moq.Object;
		}
	}
}
