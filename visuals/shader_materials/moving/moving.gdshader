shader_type spatial;


uniform sampler2D _Texture;
uniform vec2 _ScrollSpeed = vec2(1.0, 0.0);



void fragment() {
    vec2 uv = UV;
    uv += _ScrollSpeed * TIME;
    vec4 tex = texture(_Texture, uv);
    ALBEDO = tex.rgb;
    ALPHA = tex.a;
}
