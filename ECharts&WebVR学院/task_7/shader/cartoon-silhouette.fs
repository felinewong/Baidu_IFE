varying vec3 vColor;
varying vec3 vNormal;
varying vec3 vLight;

void main() {
    // vec3(1.0, 1.0, 0.0) 垂直屏幕的方向
    // vNormal * vec3(1.0, 1.0, 0.0)将法向量与视角方向进行点乘‘
    // length() 得到点乘结果的模长
    float silhouette = length(vNormal * vec3(1.0, 1.0, 0.0));
    if (silhouette < 0.90) {
        silhouette = 1.0;
    }
    else {
        silhouette = 0.0;
    }

    float diffuse = dot(normalize(vLight), vNormal);
    if (diffuse > 0.7) {
        diffuse = 1.0;
    }
    else if (diffuse > 0.5) {
        diffuse = 0.6;
    }
    else if (diffuse > 0.2) {
        diffuse = 0.4;
    }
    else {
        diffuse = 0.2;
    }
    diffuse = diffuse * silhouette;

    gl_FragColor = vec4(vColor * diffuse, 1.0);
}
