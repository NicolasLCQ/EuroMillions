---
applyTo: '**/*.cs'
title: Test Guidelines in C#
description: 'How to test C# applications.'
---

Provide context and coding guidelines that AI should follow when generating code, answering questions, or reviewing changes.

---

# Tests Guidelines

## What to test

1. Every method has to be covered by **Unit Tests**.
2. Every entrypoint has to be covered by **Integration tests**.

## How to test

1. **Unit/Integration Tests** :

 - Unit/Integration Tests have to cover every possible path.
 - Unit/Integration Tests have to be independent one from another.
 - Unit/Integration Tests have to be deterministic (always give the same result for the same input).
 - Unit/Integration Tests have to have clear names (example : `MyTestedMethod((_As((RoleName))))_Should_DoWhatItIsSupposedToDoInThisCase_When_CaseTestCondition`).
 - Unit/Integration Tests have to test explicit datas to validate the test case specifically.
 - Unit/Integration Tests have to not use the real database.
 - Unit/Integration Tests have to generate dynamical fake datas which will not be afected by aleas like time, random, etc... .
 - Unit/Integration Tests have to use Bogus/faker to generate fake datas.

2. *Unit tests** :

 - Unit tests have to test every possible combination.
 - Unit tests have to moq every dependency.
 - Unit tests have to not use the real database.
 - Unit tests have to not fake a database exept for testing the database layer.
 - Unit tests have to cover every function.
 - One test file = one tested function with all possible paths.
 - Unit tests files have to be named `MyTestedFuntion_Tests.cs`

3. **Integration tests** :

 - Integration tests have to test every api endpoints
 - Integration tests have to test every batch.
 - Integration tests have to test every possible endpoint/batch arguments combination.
 - Integration tests have to cover 100% of the application.
 - Integration tests have to not use the real database.
 - Integration tests have to fake a database filled with fake data.
 - Integration tests have to use WebApplicationFactory for testing apis.
 - One test file = one tested entrypoint with all possible paths.
 - Integration tests files have to be named `MyTestedController_MyTestedEndpoint_IntegrationTests.cs` (ex: `User_CreateUser_IntegrationTests.cs` for UserController's CreateUser endpoint).

## Test Structure

```csharp
[((Appropriate test annotation))]
public ((Appropriate method type : "void" OR "async Task" generaly)) MyTestedMethod_Should_DoWhatItIsSupposedToDo_When_CaseTestCondition()
{
    // Arrange
    -> INIT TEST DATAS IF NECESSARY
    -> INIT MOCK FOR UNIT TESTS IF NECESSARY
    
    // Act
    -> EXECUTE TESTED METHOD
    
    // Assert
    -> VERIFY THAT MYMETHOD DOES WHAT IT IS SUPPOSED TO DO
}
```

## Librairies to use

 - Use [xUnit](https://xunit.net/) framework.
 - Use [Moq](https://github.com/moq/moq4) for mocking.
 - Use [Bogus](https://github.com/bchavez/Bogus) for generating fake data.

### Prefered when using librairies

1. xUnit

 - Use `[Fact]` for simple tests.
 - Use `[Theory]` for parameterized tests.
 - With xUnit, class constructors are used for test setup, and `IDisposable.Dispose` is used for test teardown. 
   - Avoid used static private fonction for test setup. 
     - Prefer tu use class constructor (which is called before each test) for test setup.
     - Prefer to Generate specific test variables in the `Arrange` part of the test.

2. Moq

 - Use `Verify` for asserting mock interactions.

3. Bogus
 - When Creating fake datas,
   - Create a public static class named 'ModelFaker' in a helper file.
   - Create a public static method named 'ModelGenerator' in the 'ModelFaker' class that returns a `Faker<Model>` with all Model possible rules. (ex: for bolean use `RuleFor(model => model.BooleanProperty, f => f.Radom.Bool()` instead of `RuleFor(model => model.BooleanProperty,f => true)`)
   - Never fix properties for test case in the ModelFaker class. Always override them in the Arrange part of the test (ex: for a boolean, use faker to generate a random boolean do not force the value to true or false. override the rule in the arrange part of the test).
   - Using faker, Always specify the lamba even when not usefull to avoid reusing the same object for all tests (ex:`RuleFor(model => model.BooleanProperty, f => true)` instead of `RuleFor(model => model.BooleanProperty, true)`).
     - Always name this lambda `f` for homogeneity.
   - if a model A wrap an other model B, use faker for model B in the rules of model A (ex: `RuleFor(modelA => modelA.modelB, f => ModelBFaker.ModelBGenerator().Generate())` instead of `RuleFor(modelA => modelA.modelB, new ModelB()`).
 - When Generating fake datas,
   - Use `Faker.Generate()` to generate fake datas.
   - Use `Faker.Generate(x)` to generate x fake datas.
   - Use `Faker.RuleFor(modelName => modelName.propertyName, f => [override] )` to override rules during tests in "// Arrange" part. 
 

# Test example :

## test structure :

```
/src
├─ [NomApplication].sln
├─ /[NomApplication].TestHelpers
│  ├─ Helpers/
│  │  ├─ Fakers/
│  │  │  ├─ Model1Faker.cs
│  │  │  └─ Model2Faker.cs
│  │  ├─ Consts/
│  │  └─ Factorys/
├─ [NomApplication].sln
├─ /[NomApplication].[UnitTests]
│  ├─ [NomApplication].[UnitTests].csproj
│  ├─ [NomApplication].[UnitTests].TestedFunction1.cs
│  ├─ [NomApplication].[UnitTests].TestedFunction2.cs
│  └─ [NomApplication].[UnitTests].TestedFunction3.cs
├─ [NomApplication].sln
├─ /[NomApplication].[IntegrationTests]
│  ├─ [NomApplication].[IntegrationTests].csproj
│  ├─ [NomApplication].[IntegrationTests].TestedEndpoint1.cs
│  ├─ [NomApplication].[IntegrationTests].TestedEndpoint2.cs
│  └─ [NomApplication].[IntegrationTests].TestedEndpoint3.cs
```

## File example :

1. ModelFaker.cs :
```csharp
public class [Model]Faker()
{
    public Faker<[Model]> [Model]Generator()
    {
        return new Faker<[Model]>()
            .RuleFor([model] => [model].BooleanProperty, f => f.Random.Bool())
            .RuleFor([model] => [model].StringProperty, f => f.Random.String2(10))
            .RuleFor([model] => [model].IntProperty, f => f.Random.Number(1, 100));
    }
}
```
2. TestFile.cs :

```csharp
[Fact]
public void [TestedFunction]Should_DoWhatItIsSupposedToDo_When_CaseTestCondition()
{
    // Arrange
    [Model] [model] = [Model]Generator() //ovveride rules for this test before .generate()
        .RuleFor([model] => [model].BooleanProperty, f => true) //optional: only if property need to be override for test case
        .RuleFor([model] => [model].StringProperty, f => "foobar") //optional: only if property need to be override for test case
        .RuleFor([model] => [model].IntProperty, f => 3) //optional: only if property need to be override for test case
        .Generate();
        
    ResultType expectedResult = [ResultType]Generator() //ovveride rules for this test before .generate()
        .RuleFor([resultType] => [resultType].property, expectedValue) // use when possible the generated [model] above to build the expected result
        .Generate(); 
    
    // Act
    ResultType result = [TestedFunction]([model]);

    // Assert
    Assert.Equal(expectedResult, result);
}

