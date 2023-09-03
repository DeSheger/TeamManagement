import { useState } from "react";
import CompanyInfo from "../CompanyContent/CompanyInfo";

const CompanyNavigator = ({ name, descriprion }: any) => {
    const [content, setContent] = useState({
        info: true ,
        members: false,
        groups: false,
        activities: false
    });

    return (

        <div className="companyNavigator">
            <nav className="companyNavigator__menu">
                <ul className="companyNavigator__list">
                    <li className="companyNavigator__item">Info</li>
                    <li className="companyNavigator__item">Members</li>
                    <li className="companyNavigator__item">Groups</li>
                    <li className="companyNavigator__item">Activities</li>
                </ul>
            </nav>
            <section className="companyNavigator__content">
                {content.info ? <CompanyInfo />:null}
            </section>
        </div >
    )
}

export default CompanyNavigator;