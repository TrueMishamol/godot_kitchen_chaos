shader_type spatial;


uniform vec4 _TopColor : source_color = vec4(0,0,1,1);
uniform vec4 _BottomColor : source_color = vec4(1,0,0,1);



void vertex() {
	// Get scaled vertical position in object space
	float scaled_height = VERTEX.y * MODEL_MATRIX[1][1] * 2.0f;

	// Calculate normalized height (0-1 range) based on full object height
	float normalized_height = (scaled_height + abs(MODEL_MATRIX[1][1])) / (2.0 * abs(MODEL_MATRIX[1][1]));

	// Pass to fragment shader
	COLOR = mix(_BottomColor, _TopColor, normalized_height);
}

void fragment() {
	ALBEDO = COLOR.rgb;
}
