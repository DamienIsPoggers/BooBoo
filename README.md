# BooBoo
### 2D Fighting Game engine

BooBoo is a 2D fighting game engine written in C# with [Raylib_cs](https://github.com/ChrisDill/Raylib-cs) as the rendering backend and [NLua](https://github.com/NLua/NLua) for character scripting.

# Archive

BooBoo has been archived and depricated for a new engine I'm working on. I did this because I wanted more control over OpenGL objects than what Raylib gave me. 
Engine is currently private source due to it being planned to be a commercial product, but will eventually get an open source version. When it does become open source, it will be found [here.](https://github.com/aitchgames)

# Building

Building is quite simple. In Visual Studio, make sure you have [BlakieLibSharp](https://github.com/DamienIsPoggers/BlakieLibSharp) installed then just press build.

It hasn't been tested but it uses no platform specific code and should run on all platforms.

# Making Characters

BooBoo uses arbitrary binary file types for characters, but the main tools you'll need are [BlakieLibToolSet](https://github.com/DamienIsPoggers/BlakieLibToolSet) to make the animations, hitboxes, 
and other general effects, [BlakieLibAssetBuilder](https://github.com/DamienIsPoggers/BlakieLibAssetBuilder) to make the archives and sprite files, and some sort of text editor to make the 
lua scripts.
