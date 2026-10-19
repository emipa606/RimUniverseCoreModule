# GitHub Copilot Instructions for RimUniverse - Core (Continued)

## Mod Overview and Purpose
RimUniverse - Core (Continued) is a foundational mod created as an update to Balthoraz's original RimUniverse mod. This core module serves as a framework designed to integrate and enhance features from various community mods, providing a streamlined experience for players wishing to expand their RimWorld gameplay. It includes Quality of Life improvements and allows for easy management of integrated submods. This mod aims to create a cohesive environment where submodules can be enabled or disabled through mod settings, granting players control over their modded experience.

## Key Features and Systems
- **Core Framework**: Acts as the backbone for subsequent RimUniverse modules and future expansions.
- **Quality of Life Improvements**: Enhances the player's experience with practical features.
- **Modular Integration**: Easily enable or disable submods through mod settings.
- **Integrated Community Mod**: Features "Show Mod Designators" by Erdelf, providing better visualization tools for modding design aspects.
  
## Coding Patterns and Conventions
- **Code Structure**: Follow a modular structure with clear separation of concerns. Each class handles specific aspects of the mod's functions, such as controller logic, settings management, and resource handling.
  
- **Naming Conventions**: Use PascalCase for class names and camelCase for method and variable names. Ensure that method names are descriptive and indicative of their functionality.
  
- **Namespace Usage**: Group related classes under the `RimUniverse.CoreModule` namespace for improved code organization and clarity.

## XML Integration
- **About.xml**: Ensure the `About.xml` file contains all necessary metadata for the mod. This includes the `PackageId`, `Author` information, and any dependencies required for proper mod functioning.

- **XML Configuration**: Maintain XML files for definitions and configurations that the mod might need. For instance, new content or settings should be initialized in XML when applicable.

## Harmony Patching
Harmony is used to modify or extend methods in the base game without changing the original game files. This enables compatibility and longevity even with game updates.
- **Installing Harmony**: Ensure Harmony (identified by `brrainz.harmony`) is a dependency to facilitate method patching.
  
- **Creating Patches**: Use Harmony to patch methods that require alteration. This can include adding new behaviors, modifying existing ones, or fixing bugs.

- **Maintaining Compatibility**: Always test patches against the latest game updates to ensure ongoing compatibility.

## Suggestions for Copilot
- **Code Generation**: Leverage GitHub Copilot to assist in writing repetitive or boilerplate code such as property getters/setters, or standard RimWorld modding patterns.

- **Documentation**: Utilize Copilot to generate inline comments and summaries to keep the codebase well-documented for future maintenance and contributions.

- **Testing Scenarios**: Generate comprehensive tests for new features or patches using Copilot to predict and address potential issues before they occur.

- **Error Logging**: Implement enhanced error logging and reporting facilitated by Copilot to streamline debugging and user support.

By following these guidelines and suggestions, contributors and developers can maintain and extend RimUniverse - Core (Continued) to further enrich the RimWorld community modding experience.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

