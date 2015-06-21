Shader "Custom/Mirror" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Mask ("Culling Mask", 2D) = "white" {}
        _Cutoff ("Alpha cutoff", Range (0,1)) = 0.1
    }
    SubShader {
        Tags {"Queue"="Transparent"}
        Lighting On
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        AlphaTest GEqual [_Cutoff]

        Pass {
            Material {
                Diffuse (1, 1, 1, 1)
            }
            SetTexture [_Mask] {combine texture}
            SetTexture [_MainTex] {combine texture * primary DOUBLE,texture * previous}
        }
    }
} 
