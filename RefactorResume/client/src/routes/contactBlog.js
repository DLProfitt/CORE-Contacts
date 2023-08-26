import blogHeader from "../assets/contact-blog-header.png"

const ContactBlog = () => {
    return (
        <>
            <section id="hero">
                <img className="blog-header" src={blogHeader} alt="ContactBlog header" />
            </section>
            <div className="blog">
                <section className="subsection">
                    <h2>Welcome Messages</h2>
                    <h3>A tagline for Welcome Messages</h3>
                    <p>Your introductory text about welcome messages.</p>
                    <ul>
                        <li><img className="blog-header" src={blogHeader} alt="ContactBlog header" /></li>
                    </ul>

                    <h2>Welcome Messages</h2>
                    <h3>A tagline for Welcome Messages</h3>
                    <p>Your introductory text about welcome messages.</p>
                    <ul>
                        <li><img className="blog-header" src={blogHeader} alt="ContactBlog header" /></li>
                    </ul>

                    <h2>Welcome Messages</h2>
                    <h3>A tagline for Welcome Messages</h3>
                    <p>Your introductory text about welcome messages.</p>
                    <ul>
                        <li><img className="blog-header" src={blogHeader} alt="ContactBlog header" /></li>
                    </ul>
                </section>
            </div>
        </>
    );
};

export default ContactBlog;