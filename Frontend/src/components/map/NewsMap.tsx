import { YMaps, Map, Clusterer, Placemark } from '@pbe/react-yandex-maps';
import './newsMap.scss';
import CultureIcon from '../../icons/culture.svg'
import AtrractionIcon from '../../icons/Attractions.svg'
import JKXIcon from '../../icons/JKX.svg'
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { setActiveNewsArticle } from '../../slices/newsSlece';

const TagsToIcons: { [tag: string]: string } = {
  "Городская среда": CultureIcon,
  "Ремонтные работы": JKXIcon,
  "Праздники": AtrractionIcon,
  "Развлечения": AtrractionIcon,
  "Проишествия": AtrractionIcon
}
export const NewsMap = () => {
  const news = useAppSelector(state => state.news.newsArticles);
  const dispatch = useAppDispatch();
  return(
  <YMaps>
    <div>
      <Map width={"100vw"} height={"100vh"} defaultState={{ center: [53.38, 58.98], zoom: 15}} >
      <Clusterer
      options={{
        preset: "islands#invertedVioletClusterIcons",
        groupByCoordinates: false,
      }}
    >
      {news.map((elem, index) => (
        <Placemark key={index} geometry={[elem.coords.lat, elem.coords.lon]} options={{ iconLayout: "default#image", iconImageSize: [50, 50], iconImageHref: TagsToIcons[elem.tags[0]]}} onClick={()=> dispatch(setActiveNewsArticle(elem))}/>
      ))}
    </Clusterer>
        </Map>
    </div>
  </YMaps>
);
}