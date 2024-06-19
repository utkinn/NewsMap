import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { NewsArticle } from "../../DTO/NewsArticle";

export interface newsState {
    activeNewsArticle: NewsArticle | null;
    newsArticles: NewsArticle[]
}

const initialState: newsState = {
    activeNewsArticle: null,
    newsArticles: [
        {
            "title": "Через два дня в Магнитогорске официально откроют обновлённый Северный пляж",
            "content": "Некогда дикий пляж рядом с парком Ветеранов Магнитки не узнать: под ногами приятно похрустывает чистая галька, на территории расставлены красивые лежаки, в воздухе – явный запах нового дерева.",
            "publishedAt": "2024-06-18T16:17:17.208Z",
            "sourceUrl": "https://www.verstov.info/news/vip-news/cherez-dva-dnya-v-magnitogorske-ofitsialno-otkroyut-obnovlennyy-severnyy-plyazh",
            "imgUrl": "https://img.verstov.info/rs:fill/w:660/q:80/plain/https://www.verstov.info/wmark/upload/iblock/63c/6nvasoka3r6hk4igbq654iufk52c5cmr/IMG_5486.jpg",
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
            "content": "Всего за дорожный сезон в Магнитогорске в рамках нацпроекта «Безопасные качественные дороги» обновят более пяти километров дорог.Ещё несколько лет назад муниципалитеты Челябинской области и мечтать не могли о приведении в нормативное состояние дорог. В сельской местности ситуация была ещё более плачевной, чем в малых и больших городах: на ямы и ухабы в местной казне средств не было, а из областного бюджета деньги на эти цели не выделялись.",
            "publishedAt": "2024-06-18T16:17:17.208Z",
            "sourceUrl": "https://www.verstov.info/news/society/dorozhnye-raboty-po-natsproektu-v-magnitogorske-vykhodyat-na-finishnuyu-pryamuyu",
            "imgUrl": "https://img.verstov.info/rs:fill/w:660/q:80/plain/https://www.verstov.info/wmark/upload/iblock/b23/sjdcg30amboxl5jxtwat6p97akoh218z/01.jpg",
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
            "imgUrl": "",
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
            "imgUrl": "",
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
            "imgUrl": "",
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
    reducers: {
        setActiveNewsArticle: (state, action: PayloadAction<NewsArticle | null>) => {
            state.activeNewsArticle = action.payload
        }
    }
})

export const { setActiveNewsArticle } = newsSlice.actions
export default newsSlice.reducer