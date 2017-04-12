//uiform 从OpenGL代码传入顶点着色器的变量，每个顶点对应一个值
//varying  从顶点着色器传入片元着色器变量

uniform vec3 color; //统一基础颜色，每个顶点获取同样的颜色值
uniform vec3 light; //声明光源位置

//vec3 类型声明 三维向量
varying vec3 vColor;    //基础色
varying vec3 vNormal;   //顶点法向量
varying vec3 vLight;    //光源相对摄像机的坐标

//main函数会被每个顶点执行一次，并且在GPU中被执行
void main()
{
    // 传递给片元着色器
    vColor = color;

    //normalize 辅助函数 将向量归一化
    //dot 辅助函数 获得两个向量的点积
    //normalMatrix 将物体坐标系下的法向量方向转化为视图坐标系下的法向量方向
    vNormal = normalize(normalMatrix * normal);

    //光源位置乘以视图矩阵，得到光源在视图坐标系下的位置
    vec4 viewLight = viewMatrix * vec4(light, 1.0);
    vLight = viewLight.xyz;

    //将MVP矩阵乘以顶点坐标position（由着色器提供）
    gl_Position = projectionMatrix * modelViewMatrix * vec4(position, 1.0);
}
