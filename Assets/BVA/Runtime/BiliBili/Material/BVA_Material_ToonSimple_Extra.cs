using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using GLTF.Extensions;
using BVA.Extensions;
using System.Threading.Tasks;
using UnityEngine;
using Color = UnityEngine.Color;
using Vector4 = UnityEngine.Vector4;

namespace GLTF.Schema.BVA
{
    [MaterialExtra]
    public class BVA_Material_ToonSimple_Extra : IMaterialExtra
    {
        public const string PROPERTY = "BVA_Material_ToonSimple_Extra";
        public const string SHADER_NAME = "Shader Graphs/Toon (Simple)";
        public const string BASECOLOR = "_BaseColor";
        public const string BASEMAP = "_BaseMap";
        public const string SMOOTHNESS = "_Smoothness";
        public const string CURVATURE = "_Curvature";
        public const string NORMALMAP = "_NormalMap";
        public const string SHADE = "_Shade";
        public const string OUTLINEWIDTH = "_OutlineWidth";
        public const string SHADETOONY = "_ShadeToony";
        public const string TOONYLIGHTING = "_ToonyLighting";
        public const string OUTLINEINTENSITY = "_OutlineIntensity";
        public MaterialParam<Color> parameter__BaseColor = new MaterialParam<Color>(BASECOLOR, Color.white);
        public MaterialTextureParam parameter__BaseMap = new MaterialTextureParam(BASEMAP);
        public MaterialParam<float> parameter__Smoothness = new MaterialParam<float>(SMOOTHNESS, 1.0f);
        public MaterialParam<float> parameter__Curvature = new MaterialParam<float>(CURVATURE, 1.0f);
        public MaterialTextureParam parameter__NormalMap = new MaterialTextureParam(NORMALMAP);
        public MaterialParam<float> parameter__Shade = new MaterialParam<float>(SHADE, 1.0f);
        public MaterialParam<float> parameter__OutlineWidth = new MaterialParam<float>(OUTLINEWIDTH, 1.0f);
        public MaterialParam<float> parameter__ShadeToony = new MaterialParam<float>(SHADETOONY, 1.0f);
        public MaterialParam<float> parameter__ToonyLighting = new MaterialParam<float>(TOONYLIGHTING, 1.0f);
        public MaterialParam<float> parameter__OutlineIntensity = new MaterialParam<float>(OUTLINEINTENSITY, 1.0f);
        public string[] keywords;
        public string ShaderName => SHADER_NAME;
        public string ExtraName => GetType().Name;
        public void SetData(Material material, ExportTextureInfo exportTextureInfo, ExportTextureInfo exportNormalTextureInfo, ExportCubemap exportCubemapInfo)
        {
            keywords = material.shaderKeywords;
            parameter__BaseColor.Value = material.GetColor(parameter__BaseColor.ParamName);
            var parameter__basemap_temp = material.GetTexture(parameter__BaseMap.ParamName);
            if (parameter__basemap_temp != null) parameter__BaseMap.Value = exportTextureInfo(parameter__basemap_temp);
            parameter__Smoothness.Value = material.GetFloat(parameter__Smoothness.ParamName);
            parameter__Curvature.Value = material.GetFloat(parameter__Curvature.ParamName);
            var parameter__normalmap_temp = material.GetTexture(parameter__NormalMap.ParamName);
            if (parameter__normalmap_temp != null) parameter__NormalMap.Value = exportNormalTextureInfo(parameter__normalmap_temp);
            parameter__Shade.Value = material.GetFloat(parameter__Shade.ParamName);
            parameter__OutlineWidth.Value = material.GetFloat(parameter__OutlineWidth.ParamName);
            parameter__ShadeToony.Value = material.GetFloat(parameter__ShadeToony.ParamName);
            parameter__ToonyLighting.Value = material.GetFloat(parameter__ToonyLighting.ParamName);
            parameter__OutlineIntensity.Value = material.GetFloat(parameter__OutlineIntensity.ParamName);
        }
        public async Task Deserialize(GLTFRoot root, JsonReader reader, Material matCache, AsyncLoadTexture loadTexture, AsyncLoadTexture loadNormalMap, AsyncLoadCubemap loadCubemap)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var curProp = reader.Value.ToString();
                    switch (curProp)
                    {
                        case BVA_Material_ToonSimple_Extra.BASECOLOR:
                            matCache.SetColor(BVA_Material_ToonSimple_Extra.BASECOLOR, reader.ReadAsRGBAColor());
                            break;
                        case BVA_Material_ToonSimple_Extra.BASEMAP:
                            {
                                var texInfo = TextureInfo.Deserialize(root, reader);
                                var tex = await loadTexture(texInfo.Index);
                                matCache.SetTexture(BVA_Material_ToonSimple_Extra.BASEMAP, tex);
                            }
                            break;
                        case BVA_Material_ToonSimple_Extra.SMOOTHNESS:
                            matCache.SetFloat(BVA_Material_ToonSimple_Extra.SMOOTHNESS, reader.ReadAsFloat());
                            break;
                        case BVA_Material_ToonSimple_Extra.CURVATURE:
                            matCache.SetFloat(BVA_Material_ToonSimple_Extra.CURVATURE, reader.ReadAsFloat());
                            break;
                        case BVA_Material_ToonSimple_Extra.NORMALMAP:
                            {
                                var texInfo = TextureInfo.Deserialize(root, reader);
                                var tex = await loadTexture(texInfo.Index);
                                matCache.SetTexture(BVA_Material_ToonSimple_Extra.NORMALMAP, tex);
                            }
                            break;
                        case BVA_Material_ToonSimple_Extra.SHADE:
                            matCache.SetFloat(BVA_Material_ToonSimple_Extra.SHADE, reader.ReadAsFloat());
                            break;
                        case BVA_Material_ToonSimple_Extra.OUTLINEWIDTH:
                            matCache.SetFloat(BVA_Material_ToonSimple_Extra.OUTLINEWIDTH, reader.ReadAsFloat());
                            break;
                        case BVA_Material_ToonSimple_Extra.SHADETOONY:
                            matCache.SetFloat(BVA_Material_ToonSimple_Extra.SHADETOONY, reader.ReadAsFloat());
                            break;
                        case BVA_Material_ToonSimple_Extra.TOONYLIGHTING:
                            matCache.SetFloat(BVA_Material_ToonSimple_Extra.TOONYLIGHTING, reader.ReadAsFloat());
                            break;
                        case BVA_Material_ToonSimple_Extra.OUTLINEINTENSITY:
                            matCache.SetFloat(BVA_Material_ToonSimple_Extra.OUTLINEINTENSITY, reader.ReadAsFloat());
                            break;
                        case nameof(keywords):
                            {
                                var keywords = reader.ReadStringList();
                                foreach (var keyword in keywords)
                                    matCache.EnableKeyword(keyword);
                            }
                            break;
                    }
                }
            }
        }
        public JProperty Serialize()
        {
            JObject jo = new JObject();
            jo.Add(parameter__BaseColor.ParamName, parameter__BaseColor.Value.ToJArray());
            if (parameter__BaseMap != null && parameter__BaseMap.Value != null) jo.Add(parameter__BaseMap.ParamName, parameter__BaseMap.Serialize());
            jo.Add(parameter__Smoothness.ParamName, parameter__Smoothness.Value);
            jo.Add(parameter__Curvature.ParamName, parameter__Curvature.Value);
            if (parameter__NormalMap != null && parameter__NormalMap.Value != null) jo.Add(parameter__NormalMap.ParamName, parameter__NormalMap.Serialize());
            jo.Add(parameter__Shade.ParamName, parameter__Shade.Value);
            jo.Add(parameter__OutlineWidth.ParamName, parameter__OutlineWidth.Value);
            jo.Add(parameter__ShadeToony.ParamName, parameter__ShadeToony.Value);
            jo.Add(parameter__ToonyLighting.ParamName, parameter__ToonyLighting.Value);
            jo.Add(parameter__OutlineIntensity.ParamName, parameter__OutlineIntensity.Value);
            if (keywords != null && keywords.Length > 0)
            {
                JArray jKeywords = new JArray();
                foreach (var keyword in jKeywords)
                    jKeywords.Add(keyword);
                jo.Add(nameof(keywords), jKeywords);
            }
            return new JProperty(BVA_Material_ToonSimple_Extra.SHADER_NAME, jo);
        }

        public object Clone()
        {
            return new BVA_Material_ToonSimple_Extra();
        }
    }
}
