shader_type canvas_item;
render_mode unshaded; // Optimize for post-processing


// Uniforms (configurable parameters)
uniform vec2 _Center = vec2(0.5, 0.5);
uniform vec4 _Color : source_color = vec4(0, 0, 0, 1);
uniform float _Ratio = 1.0; // Y-axis compression ratio (0.0-1.0)
uniform float _Radius = 1.2;
uniform float _GradientRange = 1.3;



float calculate_vignette(vec2 uv) {
	// Apply vertical compression to coordinates
	vec2 compressed_uv = vec2(uv.x, uv.y * _Ratio);
	vec2 compressed_center = vec2(_Center.x, _Center.y * _Ratio);

	// Calculate distance from center and normalize
	float distance_from_center = distance(compressed_uv, compressed_center);
	distance_from_center /= _Radius;

	// Create smooth edge gradient
	return smoothstep(0.2, _GradientRange, distance_from_center);
}

void fragment() {
	// Apply vignette to alpha channel
	COLOR = vec4(_Color.rgb, calculate_vignette(UV));
}
