// Ix.RenderableContent.Tests
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using System;
using Xunit;
using Bunit;
using Ix.Presentation.Blazor.Controls.RenderableContent;
using Microsoft.Extensions.DependencyInjection;
using Ix.Presentation.Blazor.Services;
using System.IO;

namespace Ix.RenderableContent.Tests
{
    public class RenderableContentTests : TestContext, IClassFixture<RenderableContentTestsFixture>
    {

        private RenderableContentTestsFixture _fixture;
        private string _projectDirectory;

        public RenderableContentTests(RenderableContentTestsFixture fixture)
        {
            _fixture = fixture;
           Services.AddSingleton<ComponentService>();
           Services.AddSingleton<AttributesHandler>();
           Services.AddScoped<ViewModelCacheService>();
           _projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        }


        [Fact]
        public void Render_prgWeatherStations_Tabs_Successfull()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "prgWeatherStations.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.prgWeatherStations)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }


        [Fact]
        public void Render_stTestPrimitive_Wrap_Success()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles","stTestPrimitive.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testPrimitive)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestComplex_Success()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestComplex.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testComplex)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestEnum_Success()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestEnum.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testEnum)
            .Add(p => p.Presentation, "Control"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestRenderIgnore_Display_Date_Ignored()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestRenderIgnoreDisplay.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testRenderIgnore)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestRenderIgnore_Control_Bool_Ignored()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestRenderIgnoreControl.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testRenderIgnore)
            .Add(p => p.Presentation, "Control"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestRenderIgnore_ShadowDisplayControl_DateAndBool_Ignored()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestRenderIgnoreShadowDisplayControl.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testRenderIgnore)
            .Add(p => p.Presentation, "ShadowDisplay-ShadowControl"));
            // Assert
            cut.MarkupMatches(html);
        }


        [Fact]
        public void Render_stTestEmpty_Success()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestEmpty.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testEmpty)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestLayoutOverwrite_Success()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestLayoutOverWrite.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testLayoutOverwrite)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestMixed_Success()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestMixed.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testMixed)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestMultipleLayouts_Success()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestMultipleLayouts.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testMultipleLayouts)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestSimple_Success()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestSimple.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testSimple)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestWithoutLayouts_Success()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestWithoutLayouts.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testWithoutLayouts)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestSimpleNested_Success()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestSimpleNested.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testSimpleNested)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }

        [Fact]
        public void Render_stTestMultipleNested_TabsAndComples_Successfull()
        {
            // Arrange
            var path = Path.Combine(_projectDirectory, "HtmlFiles", "stTestMultipleNested.html");
            var html = File.ReadAllText(path);
            // Act
            var cut = RenderComponent<RenderableContentControl>(param => param
            .Add(p => p.Context, _fixture.Connector.testingProgram.testMultipleNested)
            .Add(p => p.Presentation, "Display"));
            // Assert
            cut.MarkupMatches(html);
        }



     
        //[Fact]
        //public void GetGroupElements_TestEmpty_NoLayouts_OneGroupSuccesfull()
        //{
        //    //Arrange
        //    var testPrimitive = _fixture.Connector.testingProgram.testEmpty;
        //    var expectedGroupCount = 0;


        //    //Act
        //    var parentLayout = _fixture.RenderableContent.TryLoadLayoutType(testPrimitive);
        //    var groupedElements = _fixture.RenderableContent.GroupElementsByLayouts(testPrimitive, parentLayout);

        //    //Assert
        //    Assert.NotNull(groupedElements);
        //    Assert.Equal(expectedGroupCount, groupedElements.Groups.Count());
        //    //Assert.Equal(expectedIxElementsInGroupCount, groupedElements.Count);
        //}


        //[Fact]
        //public void Render_testingProgram_testRenderIgnoreAttributes_Display_KidsCountEqual()
        //{
        //    //Arrange
        //    var __builder = new RenderTreeBuilder();
        //    var testRenderIgnore = _fixture.Connector.testingProgram.testRenderIgnore;
        //    _fixture.RenderableContent.Presentation = Presentation.Blazor.Enums.PresentationType.Display;
        //    var ignoredPropCount = 2;
        //    var expectedCount = testRenderIgnore.GetKids().Count() - ignoredPropCount;

        //    //Act
        //    var renderer = _fixture.RenderableContent.RenderComponent(testRenderIgnore);
        //    renderer.Invoke(__builder);
        //    var frames = __builder.GetFrames();
        //    var ixAttributeCount = frames.Array.AsEnumerable().Where(x => x.AttributeName == AttributeNameIx).Count();

        //    //Assert
        //    Assert.Equal(ixAttributeCount, expectedCount);

        //}

        

    }
}
