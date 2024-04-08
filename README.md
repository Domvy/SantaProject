# SantaProject
### 2D 횡스크롤 게임
___
[프로젝트 시작 이유](#프로젝트-시작-이유)  

[프로젝트를 통해 배운 것들](#프로젝트를-통해-배운-것들)  

[특징](#특징)


#### 프로젝트 시작 이유  
스터디의 효율을 높여보기 위해서 목표를 정해 일정 기간동안 앱을 제작해 보기로 했고, 작은 규모의 게임을 만들어 보기로 했다.  
3D보다 비교적 제작이 간편해 보이는 2D 형태로 만들면서 어린이 유저들을 위한 게임을 만들기로 시작했다.  
여러 아이디어 중 슈퍼마리오를 비롯한 플랫포머 게임 형태로 만들어 보는 것을 제안했고 거기에 몇 개의 미니게임을 덧붙이는 형태로 결정했다.  

![슈퍼마리오 이미지](https://github.com/Domvy/SantaProject/assets/90752171/db566404-6feb-4f7d-8b97-b74b799e3428)  
겨울 크리스마스 시즌 완성을 목표로 6개월의 시간을 가지고 제작했다.  
게임 주요 내용은 이렇다.  

**1. 스테이지 형식의 횡스크롤 게임으로 저연령층이 쉽게 플레이 할 수 있도록 만든다.**  

**2. 크리스마스 배경의 산타가 주인공으로 선물을 배달하는 과정을 게임으로 만들었다.**  

**3. 안드로이드 플랫폼의 모바일 게임으로, 온라인 연동 없이 싱글 게임이다.**  


> 게임의 시작 화면 & 플레이 중 화면
>> ![start screen_01(done)](https://github.com/Domvy/SantaProject/assets/90752171/906bca4d-1137-4348-b032-c0163acc9166)
>> ![스테이지2](https://github.com/Domvy/SantaProject/assets/90752171/983060f8-c95c-4cfb-b4bb-f1783c603b19)

  
#### 프로젝트를 통해 배운 것들  

* 스마트폰의 기종에 따라 해상도, 비율이 다르기 때문에 기종별로 설정하거나, 일정 비율로 통일해놓아야 한다.  
  스크립트를 이용해 해상도 비율을 FHD 비율로 통일하는 방법으로 해결하였다.
  
  [CameraRect.cs](SantaProject(240107)/Assets/Resources/CameraRect.cs)  
  [CameraScript.cs](SantaProject(240107)/Assets/Script/GameMgr/CameraScript.cs)
  
```
  private void SetResolution()
{
    if (camera == null) { camera = Camera.main; }

    int setWidth = 1920;
    int setHeight = 1080;

    int deviceWidth = Screen.width;
    int deviceHeight = Screen.height;

    Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true);

    if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight)
    {
        float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight);
        camera.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f);
    }
    else
    {
        float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight);
        camera.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight);
    }
}
```
* 2D 횡스크롤 게임을 만들면서 당연하게 생각하던 부분들이 막상 어렵게 다가왔었다.  
  플레이어의 이동과 점프, 발판과의 상호작용 등 찾아보아야 할 부분이 많았다.  
  플레이어의 이동은 유니티 인풋시스템을 사용하여 구현했고 바닥 물리효과를 위해 velocity 값을 이용해 이동하도록 하였다.
  
  ![플레이어인풋](https://github.com/Domvy/SantaProject/assets/90752171/da526ed7-6ea4-4299-a5da-6e3a12ee7637)
  플레이어 조작 스크립트 : [PlayerCtrl.cs](SantaProject(240107)/Assets/Script/Player/PlayerCtrl.cs)
  
  플레이어가 밟으면서 상호작용을 해야 할 발판은 Collider를 사용하고 특정 방향만 인식하도록 PlatformEffecter2D를 사용했다.
  또한 PhysicsMaterial을 Collider에 사용해 미끄러운 발판 등을 구현했다.  
  ![스크린샷 2024-04-09 031723](https://github.com/Domvy/SantaProject/assets/90752171/d312eaca-0ecf-4f98-89e6-aa8d3e76609c)

  게임 플레이 화면
  
  ![움직임1](https://github.com/Domvy/SantaProject/assets/90752171/21f10a9e-3f89-4e25-8a0e-5917e49bab1f)
  ![움직임2](https://github.com/Domvy/SantaProject/assets/90752171/461355c8-84e3-4810-9e5a-f8a2aebe893e)


* 세 번째 스테이지는 조금 독특한 방법으로 만들어 보았는데, 건물을 회전시키기 위해서 이미지 스프라이트를 사각형 형태로 만들어 회전시켰다.
  플레이어 위치에 맞추어 회전시키고 다시 게임을 이어나가게 하도록 만들었다.

#### 특징  
사용한 언어  

[![Top Langs](https://github-readme-stats.vercel.app/api/top-langs/?username=Domvy)](https://github.com/anuraghazra/github-readme-stats)
