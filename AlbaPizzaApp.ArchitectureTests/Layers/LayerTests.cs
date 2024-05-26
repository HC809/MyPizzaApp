using AlbaPizzaApp.Application.Abstractions.Messaging;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Infraestructure;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NetArchTest.Rules;

namespace AlbaPizzaApp.ArchitectureTests.Layers;
public class LayerTests
{
    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_ApplicationLayer()
    {
        TestResult result = Types.InAssembly(typeof(Entity).Assembly)
            .Should()
            .NotHaveDependencyOn(typeof(IBaseCommand).Assembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        TestResult result = Types.InAssembly(typeof(Entity).Assembly)
            .Should()
            .NotHaveDependencyOn(typeof(ApplicationDbContext).Assembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    //[Fact]
    //public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    //{
    //    TestResult result = Types.InAssembly(typeof(IBaseCommand).Assembly)
    //        .Should()
    //        .NotHaveDependencyOn(typeof(ApplicationDbContext).Assembly.GetName().Name)
    //        .GetResult();

    //    result.IsSuccessful.Should().BeTrue();
    //}

    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_APILayer()
    {
        TestResult result = Types.InAssembly(typeof(IBaseCommand).Assembly)
            .Should()
            .NotHaveDependencyOn(typeof(Program).Assembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void InfrastructureLayer_ShouldNotHaveDependencyOn_APILayer()
    {
        TestResult result = Types.InAssembly(typeof(ApplicationDbContext).Assembly)
            .Should()
            .NotHaveDependencyOn(typeof(Program).Assembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
