import { YMaps, Map, Clusterer, Placemark } from '@pbe/react-yandex-maps';
import './newsMap.scss';
import CultureIcon from '../../newsIcons/culture.svg'
import AtrractionIcon from '../../newsIcons/Attractions.svg'
import JKXIcon from '../../newsIcons/JKX.svg'
import IncindentIcon from '../../newsIcons/incindent.svg'
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { setActiveNewsArticle } from '../../slices/newsSlece';
import { useEffect } from 'react';
import { FetchNews } from '../../actions/newsAction';

const TagsToIcons: { [tag: string]: string } = {
  "Городская среда": CultureIcon,
  "Ремонтные работы": JKXIcon,
  "Праздники": AtrractionIcon,
  "Развлечения": AtrractionIcon,
  "Проишествия": IncindentIcon,
}
export const NewsMap = () => {
  const news = useAppSelector(state => state.news.newsArticles);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(FetchNews())
    const fetchInterval = setInterval(() => {
      dispatch(FetchNews())
    }, 10000);

    return () => clearInterval(fetchInterval)
  }, [dispatch])
  return (
    <YMaps>
      <div>
        <Map width={"100vw"} height={"100vh"} defaultState={{ center: [53.38, 58.98], zoom: 15 }} >
          <Clusterer
            options={{
              preset: "islands#invertedVioletClusterIcons",
              groupByCoordinates: false,
            }}
          >
            {news.map((elem, index) => (
              <Placemark key={index} geometry={[elem.coords.lat, elem.coords.lon]} options={{ iconLayout: "default#image", iconImageSize: [50, 50], iconImageHref: TagsToIcons[elem.tags[0]] }} onClick={() => dispatch(setActiveNewsArticle(elem))} />
            ))}
          </Clusterer>
        </Map>
      </div>
    </YMaps>
  );
}