shader_type canvas_item;

// intensidade das falhas horizontais
uniform float glitch_amount : hint_range(0.0, 1.0) = 0.2;

// separação de cores (RBG split)

uniform float shift_amount : hint_range(0.0, 1.0) = 0.01;

// velocidade da animação do glitch

uniform float speed = 15.0;

float random(vec2 uv) {
	return fract(sin(dot(uv.xy, vec2(12.9898, 78.233))) * 43758.5453);
}

void fragment() {
	vec2 uv = UV;

	// blocos horizontais baseados no tempo para distorcer a linha do texto

	float glitch_time = floor(TIME * speed);
	
	float glitch_line = random(vec2(glitch_time, floor(uv.y * 120.0)));

	// se passar do limite, aplica o deslocamento horizontal na textura
	
	if (glitch_line < glitch_amount) {

		uv.x += (random(vec2(glitch_time, uv.y)) - 0.5) * shift_amount * 3.0;

}

// separacão de canais RGB para dar o efeito cromático digital

float r = texture(TEXTURE, uv + vec2(shift_amount, 0.0)).r;

float g = texture(TEXTURE, uv).g;

float b = texture(TEXTURE, uv - vec2(shift_amount, 0.0)).b;

float a = texture(TEXTURE, uv).a;

// garante que o canal alpha (transparência) acompanhe os desvios

float max_a = max(texture(TEXTURE, uv + vec2(shift_amount, 0.0)).a, texture(TEXTURE, uv - vec2(shift_amount, 0.0)).a);

COLOR = vec4(r, g, b, max(a, max_a));

}