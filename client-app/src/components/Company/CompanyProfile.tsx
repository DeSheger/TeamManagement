import CompanyNavigator from "./CompanyNavigator/CompanyNavigator";

const CompanyProfile = ({name, descriprion}:any) => {

    return (
        <div className="companyProfile">
            <header className="companyProfile__header">
                <h2 className="companyProfile__header-name">{name}</h2>
                <p className="companyProfile__header-description">{descriprion}</p>
            </header>
            <section className="companyProfile__main">
                <CompanyNavigator>
                    
                </CompanyNavigator>
            </section>
        </div>
    )
}

export default CompanyProfile;