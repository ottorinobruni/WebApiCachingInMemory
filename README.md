# WebApiCachingInMemory

This repository demonstrates different caching strategies in .NET, from basic in-memory caching to advanced HybridCache implementation. It provides practical examples using Minimal APIs and C#, showing the evolution of caching approaches in modern .NET applications.

## Usage Instructions

The main branch contains the initial code used in the tutorial. Separate tags and branches are available for different implementations and examples, which you can review or download.

- **Redis Cache Implementation**: Learn how to set up Redis caching in your .NET Minimal API.
- **In-Memory Caching**: Explore the previous implementation of in-memory caching in .NET Console apps.
- **Hybrid Cache**: Discover how to combine in-memory and distributed caching (e.g., Redis) to achieve a balance between performance and scalability. This implementation ensures that frequently accessed data is served quickly from memory while maintaining consistency with a distributed cache for larger datasets.

## Contents

- [Project Description](#project-description)
- [How to Run the Project](#how-to-run-the-project)
- [Links to Tutorials](#links-to-tutorials)
- [Contributions](#contributions)
- [License](#license)

## Project Description

The **WebApiCachingInMemory** project was created as part of a detailed tutorial available on my blog. This application showcases how to use Redis for caching in a .NET Minimal API context, covering:

- **Setting Up Redis**: Step-by-step instructions on how to run Redis locally using Docker.
- **Implementing Caching**: Transition from in-memory caching to distributed caching with Redis.
- **Handling Performance**: Efficiently scaling your application to handle larger loads.

## How to Run the Project

To run the project locally on your machine, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/ottorinobruni/WebApiCachingInMemory.git
    ```

2. Checkout the desired branch for the caching implementation:
    ```bash
    git checkout main    # For in-memory caching
    git checkout redis   # For Redis caching
    git checkout hybrid  # For HybridCache
    ```

3. Navigate to the project directory:
    ```bash
    cd WebApiCachingInMemory
    ```

4. Restore the dependencies:
    ```bash
    dotnet restore
    ```

5. Build the project:
    ```bash
    dotnet build
    ```

6. Run the project:
    ```bash
    dotnet run
    ```

## Links to Tutorials

For more in-depth information, check out the following tutorials on my blog:

- [How to Implement Redis Cache in .NET Using Minimal APIs and C#](https://www.ottorinobruni.com/how-to-implement-redis-cache-in-dotnet-using-minimal-apis-and-csharp/)
- [How to Implement In-Memory Caching in .NET Console Apps Using C#](https://www.ottorinobruni.com/how-to-implement-in-memory-caching-in-dotnet-console-app-using-csharp/)
- [How to Implement HybridCache in .NET using C#](https://www.ottorinobruni.com/how-to-implement-hybridcache-in-dotnet-using-csharp-a-better-caching-strategy/)


## Contributions

Contributions are welcome! If you'd like to improve this project, feel free to open a pull request or report an issue.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---
