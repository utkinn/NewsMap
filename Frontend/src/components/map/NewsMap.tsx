import { YMaps, Map, Clusterer, Placemark, Polygon } from '@pbe/react-yandex-maps';
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

const TagsToPolygonColor: { [tag: string]: string} = {
    "Городская среда": "#548FD6",
    "Ремонтные работы": "#D65454",
    "Праздники": "#D6B154",
    "Развлечения": "#D6B154",
    "Проишествия": "#D65454",
}

interface FilterType {
    [key: string]: boolean;
}
export const NewsMap = () => {
    const news = useAppSelector(state => state.news.newsArticles);
    const dispatch = useAppDispatch();
    const filter: FilterType = useAppSelector(state => state.news.filter);
    //@ts-ignore
    console.log(JSON.parse(news[2].drawData))
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
                                {filter[TagsToKey[elem.tags[0] as keyof typeof TagsToKey]] ? 
                                    <Placemark key={index} geometry={[elem.coordinates.lat, elem.coordinates.long]} options={{ iconLayout: "default#image", iconImageSize: [50, 50], iconImageHref: TagsToIcons[elem.tags[0]] }} onClick={() => dispatch(setActiveNewsArticle(elem))} /> 
                                : null}                            
                            </React.Fragment>
                        ))}
                    </Clusterer>
                    {news.map((elem, index) =>(
                        <React.Fragment>
                            {filter[TagsToKey[elem.tags[0] as keyof typeof TagsToKey]] && elem.drawData ? <Polygon geometry={JSON.parse(elem.drawData)} options={{ fillColor: TagsToPolygonColor[elem.tags[0]] + "80", strokeColor: TagsToPolygonColor[elem.tags[0]] , opacity: 1, strokeWidth: 3, strokeStyle: "shortdash" }} />:null}
                        </React.Fragment>
                    ))}
                </Map>
            </div>
        </YMaps>
    );
}