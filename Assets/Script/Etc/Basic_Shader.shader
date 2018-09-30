Shader "blaS1N/Glass" {

	Properties {
		_Tex("Texture", 2D) = "while" {}
	}

	SubShader {
		Pass {			
			SetTexture[_Tex] {
				Combine Texture * primary
			}
		}
	}

	FallBack "Diffuse"
}
