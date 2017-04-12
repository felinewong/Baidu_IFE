//从顶点着色器传递过来的变量
varying vec3 vColor;
varying vec3 vNormal;
varying vec3 vLight;

void main() {

    //归一化后的光源方向和法向量进行点乘，计算每个片元的亮度
    float diffuse = dot(normalize(vLight), vNormal);

    //得到新亮度
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

    //物体的基础颜色RGB通道分别乘以新亮度并复制给gl_FragColor作为片元的颜色输出
    gl_FragColor = vec4(vColor * diffuse, 1.0);
}
