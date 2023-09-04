import CompanyNavigator from "../../components/Company/CompanyNavigator/CompanyNavigator";
import { useEffect, useState } from "react";
import getCompanies from "../../services/getCompanies";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";


const CompanyIterate = (companies: any) => {

    if(companies instanceof Array)
        return companies.map((company:any) => company?<h3>{company.name}</h3>
        :null)
    else {
        return "No companies"
    }
}

const Companies = ({theme}:any) => {
    const [companies, setCompanies] = useState([]);
    const session = useSelector((state:RootState)=> state.session)

    useEffect(() => {
        console.log(session)
        getCompanies(session)
            .then((val) => setCompanies(val))
            .catch((err) => console.log(err))
            
    },[session])

    return (
        <div className="companies">
            <div className="companies__sidebar">
                {CompanyIterate(companies)}
            </div>
            <section className="companies__content">
                <CompanyNavigator />

            </section>
        </div>
    );
}

export default Companies;