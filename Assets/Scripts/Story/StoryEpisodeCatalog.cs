using System;
using UnityEngine;

namespace KirbyFanPrototype.Story
{
    [Serializable]
    public struct StageEpisode
    {
        public string opening;
        public string eventLine;
        public string clearLine;
    }

    [CreateAssetMenu(menuName = "Fan Prototype/Story Episodes")]
    public sealed class StoryEpisodeCatalog : ScriptableObject
    {
        public StageEpisode[] episodes = new StageEpisode[13]
        {
            new(){opening="바람꽃 축제의 별풍차가 갑자기 멈췄어요.",eventLine="겁먹은 새들이 풍차 안에 숨은 별벌레를 가리킵니다.",clearLine="풍차가 돌자 마을까지 향긋한 바람이 돌아왔어요!"},
            new(){opening="산호빛 항구의 바닷물이 하늘로 거꾸로 흐릅니다.",eventLine="웨이들 디 선장이 뒤집힌 배에서 구조 신호를 보냅니다.",clearLine="물길이 돌아오고 항구에는 무지개 물보라가 피어났어요."},
            new(){opening="덩굴 시계탑이 어제와 오늘을 마구 뒤섞고 있어요.",eventLine="에피린이 멈춘 초침 사이에서 작은 문을 발견합니다.",clearLine="시계가 정오를 알리자 갇혀 있던 시간이 풀려났어요."},
            new(){opening="달빛 놀이섬의 기구들이 손님 없이 혼자 움직입니다.",eventLine="유령 열차가 훔친 별표를 싣고 최고 속도로 달아납니다.",clearLine="별표를 되찾자 모두가 밤새 축제를 즐겼어요."},
            new(){opening="눈보라 온실의 봄꽃들이 수정 얼음에 갇혔어요.",eventLine="얼음 능력으로는 깨지지 않는 따뜻한 얼음을 발견합니다.",clearLine="친구들의 응원이 얼음을 녹이고 꽃눈이 한꺼번에 터졌어요."},
            new(){opening="용암 제빵소의 거대한 오븐이 화산보다 뜨거워졌어요.",eventLine="반죽 괴물이 빵 모자를 쓰고 불꽃로를 지키고 있습니다.",clearLine="오븐이 식자 세상에서 가장 큰 별빵이 완성됐어요."},
            new(){opening="모래별 도서관의 책들이 모래폭풍을 타고 도망칩니다.",eventLine="마지막 책에는 검은 별로 가는 오래된 지도가 숨어 있어요.",clearLine="책들이 제자리로 돌아가며 비밀 항로를 펼쳐 보였어요."},
            new(){opening="장난감 비행장의 태엽 비행선이 통제 불능이 됐어요.",eventLine="작은 정비공 웨이들 디가 날개 위에서 나사를 붙잡고 있습니다.",clearLine="비행선은 적이 아니라 길을 잃은 장난감이었다는 게 밝혀졌어요."},
            new(){opening="무지개 구름성으로 가는 일곱 빛깔 다리가 끊어졌어요.",eventLine="색을 잃은 구름들이 각자 좋아했던 색을 기억해 냅니다.",clearLine="일곱 구름이 손을 잡자 새로운 무지개 길이 생겼어요."},
            new(){opening="심해 음악당에서 모든 소리가 사라졌습니다.",eventLine="말 대신 빛으로 노래하는 고래가 잃어버린 음표를 건넵니다.",clearLine="마지막 종이 울리자 바다 전체가 합창을 시작했어요."},
            new(){opening="유령 우체국에 백 년 동안 배달되지 못한 편지가 있어요.",eventLine="편지의 주인은 최종 보스를 막으려던 옛 별지기였습니다.",clearLine="편지가 도착하자 유령 우체부들은 환한 별빛으로 떠났어요."},
            new(){opening="운석 발전소가 검은 별의 힘에 끌려가고 있습니다.",eventLine="지금까지 구한 친구들이 각자의 방식으로 발전소를 붙잡습니다.",clearLine="모두의 힘으로 최종 왕좌로 향하는 문이 열렸어요."},
            new(){opening="검은 별의 왕좌에서 모든 세계의 빛이 꺼져 갑니다.",eventLine="모았던 별 조각들이 친구들의 목소리와 함께 빛납니다.",clearLine="검은 별은 사라지지 않고 작은 새벽별로 다시 태어났어요."}
        };

        public StageEpisode Get(int stageNumber)
        {
            return episodes[Mathf.Clamp(stageNumber - 1, 0, episodes.Length - 1)];
        }
    }
}
