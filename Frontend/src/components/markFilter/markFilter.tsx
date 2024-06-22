import React, { useState } from "react";
import {ReactComponent as MarkFilterIcon} from "../../icons/markFilter.svg";
import {ReactComponent as NewsIcon} from "../../icons/newsButton.svg";
import {ReactComponent as AttractionIcon} from "../../icons/attractionsNews.svg";
import {ReactComponent as CultureIcon} from "../../icons/cultureNews.svg";
import {ReactComponent as JKXIcon} from "../../icons/jkxNews.svg";
import { useAppDispatch, useAppSelector } from "../../app/hooks";

import './markFilter.scss';
import { setFilter } from "../../slices/newsSlece";

export const MarkFilter = () => {
    const [openFilterMenu, setOpenFilterMenu] = useState(false);
    const dispatch = useAppDispatch();
    const filter = useAppSelector(state => state.news.filter);

    return (
        <React.Fragment>
        <div className={openFilterMenu ? 'mark-filter active-mark-filter' : 'mark-filter'} onClick={() => setOpenFilterMenu(!openFilterMenu)}>
            <MarkFilterIcon/>
            <span>Фильтр меток</span>
        </div>
        {openFilterMenu ? <div className="mark-list">
            <NewsIcon className={filter.news ? "": "filtred"} onClick={() => dispatch(setFilter({news: !filter.news, attraction: filter.attraction, culture: filter.culture, jkx: filter.jkx}))}/>
            <AttractionIcon className={filter.attraction ? "": "filtred"} onClick={() => dispatch(setFilter({news: filter.news, attraction: !filter.attraction, culture: filter.culture, jkx: filter.jkx}))}/>
            <CultureIcon className={filter.culture ? "": "filtred"} onClick={() => dispatch(setFilter({news: filter.news, attraction: filter.attraction, culture: !filter.culture, jkx: filter.jkx}))}/>
            <JKXIcon className={filter.jkx ? "": "filtred"} onClick={() => dispatch(setFilter({news: filter.news, attraction: filter.attraction, culture: filter.culture, jkx: !filter.jkx}))}/>
        </div> : null}
        </React.Fragment>
    )
}