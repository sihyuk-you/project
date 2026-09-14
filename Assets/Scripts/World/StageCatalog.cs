using System;
using UnityEngine;

namespace KirbyFanPrototype.World
{
    [Serializable] public struct StageInfo { public string title; public string mission; public int starGoal; }

    [CreateAssetMenu(menuName = "Fan Prototype/Stage Catalog")]
    public sealed class StageCatalog : ScriptableObject
    {
        public StageInfo[] stages = new StageInfo[13]
        {
            new(){title="바람꽃 언덕",mission="숨은 별 조각 찾기",starGoal=5},
            new(){title="산호빛 항구",mission="물길 열기",starGoal=5},
            new(){title="덩굴 시계탑",mission="시간 장치 복구",starGoal=6},
            new(){title="달빛 놀이섬",mission="야간 열차 추격",starGoal=6},
            new(){title="눈보라 온실",mission="얼어붙은 꽃 구출",starGoal=7},
            new(){title="용암 제빵소",mission="불꽃로 정지",starGoal=7},
            new(){title="모래별 도서관",mission="잃어버린 지도 회수",starGoal=8},
            new(){title="장난감 비행장",mission="폭주 비행선 격파",starGoal=8},
            new(){title="무지개 구름성",mission="구름 다리 연결",starGoal=9},
            new(){title="심해 음악당",mission="침묵의 종 연주",starGoal=9},
            new(){title="유령 우체국",mission="별 편지 배달",starGoal=10},
            new(){title="운석 발전소",mission="핵심로 안정화",starGoal=10},
            new(){title="검은 별의 왕좌",mission="최종 보스 격파",starGoal=12}
        };
    }
}
