import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { NewsArticle } from "../../DTO/NewsArticle";

export interface newsState {
    activeNewsArticle: NewsArticle|null;
    newsArticles: NewsArticle[]
  }
  
  const initialState: newsState = {
    activeNewsArticle: null,
    newsArticles: [
        {
          "title": "Через два дня в Магнитогорске официально откроют обновлённый Северный пляж",
          "content": "Инфа",
          "publishedAt": "2024-06-18T16:17:17.208Z",
          "sourceUrl": "https://www.verstov.info/news/vip-news/cherez-dva-dnya-v-magnitogorske-ofitsialno-otkroyut-obnovlennyy-severnyy-plyazh",
          "tags": [
            "Городская среда"
          ],
          "coords": {
            "lat": 53.43152778,
            "lon": 59.00347222
          }
        },
        {
          "title": "Дорожные работы по нацпроекту в Магнитогорске выходят на финишную прямую",
          "content": "Инфа",
          "publishedAt": "2024-06-18T16:17:17.208Z",
          "sourceUrl": "https://www.verstov.info/news/society/dorozhnye-raboty-po-natsproektu-v-magnitogorske-vykhodyat-na-finishnuyu-pryamuyu",
          "tags": [
            "Городская среда",
            "Ремонтные работы"
          ],
          "coords": {
            "lat": 53.368796972295904,
            "lon": 58.9901959984431
          }
        },
        {
          "title": "В Магнитогорске отметили Сабантуй, а главе города подарили лошадь",
          "content": "Инфа",
          "publishedAt": "2024-06-18T16:17:17.208Z",
          "sourceUrl": "https://www.verstov.info/news/dosug/v-magnitogorske-otmetili-sabantuy-a-glave-goroda-podarili-loshad",
          "tags": [
            "Праздники",
            "Развлечения"
          ],
          "coords": {
            "lat": 53.401636003346134,
            "lon": 58.99230339693254
          }
        },
        {
          "title": "Объединяющий сезон – в Магнитогорске наградили победителей юбилейной игры-викторины",
          "content": "Инфа",
          "publishedAt": "2024-06-18T16:17:17.208Z",
          "sourceUrl": "https://www.verstov.info/news/dosug/obedinyayushchiy-sezon-v-magnitogorske-nagradili-pobediteley-yubileynoy-igry-viktoriny",
          "tags": [
            "Развлечения"
          ],
          "coords": {
            "lat": 53.40721895088664,
            "lon": 58.9823288793991
          }
        },
        {
          "title": "В Магнитогорске установили личность самокатчика, который сбил двухлетнего ребенка",
          "content": "Инфа",
          "publishedAt": "2024-06-18T16:17:17.208Z",
          "sourceUrl": "https://www.verstov.info/news/criminal/v-magnitogorske-ustanovili-lichnost-samokatchika-kotoryy-sbil-dvukhletnego-rebenka",
          "tags": [
            "Проишествия",
            "ДТП"
          ],
          "coords": {
            "lat": 53.41191153558964,
            "lon": 58.98472496324667
          }
        }
      ]
  };

export const newsSlice = createSlice({
    name: "user",
    initialState,
    reducers:{
        setActiveNewsArticle: (state, action:PayloadAction<NewsArticle|null>)=>{
            state.activeNewsArticle = action.payload
        }
    }
})

export const {setActiveNewsArticle} = newsSlice.actions
export default newsSlice.reducer