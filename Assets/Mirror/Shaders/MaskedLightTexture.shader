Shader "MaskedLightTexture" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,0)
        _SpecColor ("Spec Color", Color) = (1,1,1,1)
        _Emission ("Emmisive Color", Color) = (0,0,0,0)
        _Shininess ("Shininess", Range (0.01, 1)) = 0.7
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Mask ("Culling Mask", 2D) = "white" {}
        _Cutoff ("Alpha cutoff", Range (0,1)) = 0.1
    }
    SubShader {
        Tags {"Queue"="Transparent"}
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        AlphaTest GEqual [_Cutoff]
 
        Pass {
            Material {
                Diffuse [_Color]
                Ambient [_Color]
                Shininess [_Shininess]
                Specular [_SpecColor]
                Emission [_Emission]
            }
            Lighting On
            SeparateSpecular On
            SetTexture [_Mask] {combine texture}
            SetTexture [_MainTex] {combine texture * primary DOUBLE,texture * previous}
        }
    }
} 