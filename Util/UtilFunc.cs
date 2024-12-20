﻿using System;
using System.Numerics;
using BlakieLibSharp;
using Raylib_cs;
using Assimp;

namespace BooBoo.Util
{
    internal static class UtilFunc
    {
        public static void LoadTexturesToGPU(this DPSpr spr)
        {
            foreach(DPSpr.Sprite sprite in spr.sprites.Values)
                unsafe
                {
                    uint id = Rlgl.LoadTexture(sprite.imageDataPtr, sprite.width, sprite.height,
                        sprite.indexed ? PixelFormat.UncompressedGrayscale : PixelFormat.UncompressedR8G8B8A8, 1);
                    //Console.WriteLine(id);
                    Rlgl.TextureParameters(id, Rlgl.TEXTURE_MIN_FILTER, Rlgl.TEXTURE_FILTER_NEAREST);
                    Rlgl.TextureParameters(id, Rlgl.TEXTURE_MAG_FILTER, Rlgl.TEXTURE_FILTER_NEAREST);
                    Rlgl.TextureParameters(id, Rlgl.TEXTURE_WRAP_S, Rlgl.TEXTURE_WRAP_MIRROR_REPEAT);
                    Rlgl.TextureParameters(id, Rlgl.TEXTURE_WRAP_T, Rlgl.TEXTURE_WRAP_MIRROR_REPEAT);
                    spr.SpriteIsOnGPU(sprite.name, id);
                }
        }

        public static void DeleteTexturesFromGPU(this DPSpr spr)
        {
            foreach (DPSpr.Sprite sprite in spr.sprites.Values)
                Rlgl.UnloadTexture(sprite.glTexId);
        }

        public static void LoadTexturesToGPU(this PrmAn an)
        {
            foreach(PrmAn.Texture tex in an.textures.Values)
            {
                Image img = Raylib.LoadImageFromMemory(tex.name.Substring(tex.name.LastIndexOf(".")), tex.texDat);
                Texture2D texture = Raylib.LoadTextureFromImage(img);
                an.TexOnGPU(tex.id, texture.Id);
            }
        }

        public static void DeleteTexturesFromGPU(this PrmAn an)
        {
            foreach (PrmAn.Texture tex in an.textures.Values)
                Rlgl.UnloadTexture(tex.glTexId);
        }

        public static Vector2 XY(this Vector3 vec)
        {
            return new Vector2(vec.X, vec.Y);
        }

        public static Vector3 ToVector3(this Vector2 vec)
        {
            return new Vector3(vec.X, vec.Y, 0.0f);
        }

        public static Vector3 ToVector3(this Vector2 vec, float z)
        {
            return new Vector3(vec.X, vec.Y, z);
        }

        public static Vector3 ToVector3(this Vector3D vec)
        {
            return new Vector3(vec.X, vec.Y, vec.Z);
        }

        public static Vector2 ToVector2(this Vector3D vec)
        {
            return new Vector2(vec.X, vec.Y);
        }

        public static Vector4 ToVector4(this Color4D color)
        {
            return new Vector4(color.R, color.G, color.B, color.A);
        }
    }
}
