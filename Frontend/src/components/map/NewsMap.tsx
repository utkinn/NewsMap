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
import React from 'react';

const TagsToIcons: { [tag: string]: string } = {
    "Городская среда": CultureIcon,
    "Ремонтные работы": JKXIcon,
    "Праздники": AtrractionIcon,
    "Развлечения": AtrractionIcon,
    "Проишествия": IncindentIcon,
}

const TagsToKey: { [tag: string]: string } = {
    "Городская среда": "culture",
    "Ремонтные работы": "jkx",
    "Праздники": "attraction",
    "Развлечения": "attraction",
    "Проишествия": "news",
}

interface FilterType {
    [key: string]: boolean;
}
export const NewsMap = () => {
    const news = useAppSelector(state => state.news.newsArticles);
    const dispatch = useAppDispatch();
    const filter: FilterType = useAppSelector(state => state.news.filter);

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
                            <React.Fragment>
                            {filter[TagsToKey[elem.tags[0] as keyof typeof TagsToKey]] ? <Placemark key={index} geometry={[elem.coordinates.lat, elem.coordinates.long]} options={{ iconLayout: "default#image", iconImageSize: [50, 50], iconImageHref: TagsToIcons[elem.tags[0]] }} onClick={() => dispatch(setActiveNewsArticle(elem))} /> : null}
                            </React.Fragment>
                        ))}
                    </Clusterer>
                </Map>
            </div>
        </YMaps>
    );
}