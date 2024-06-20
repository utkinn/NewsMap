import { toast } from "react-toastify";
import { AppDispatch } from "../app/store";
import { setNewsArticles } from "../slices/newsSlece";



export const FetchNews= () => async(dispatch: AppDispatch) => {
    try{
        const response = await fetch('/api/articles')
        if (!response.ok) {
            throw new Error('В ответе какая-от лажа');
        }

        const data = await response.json();
        dispatch(setNewsArticles(data))

    } catch(err:any) {
        console.log(err);
        //toast.error(err.toString())
    }
}