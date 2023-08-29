import blogHeader from "../assets/contact-blog-header.png"

const ContactBlog = () => {
    return (
        <>
            <section id="hero">
                <img className="blog-header" src={blogHeader} alt="ContactBlog header" />
            </section>
            <div className="blog">
                <div class="container">
                    <h1 class="header">CORE Contacts: Contact Management Guide</h1>
                    <p>With CORE Contacts, you'll experience clean and easy contact management. This guide is designed to help you <strong>Connect</strong>, <strong>Organize</strong>, <strong>Reference</strong>, and <strong>Engage</strong> with your contacts effortlessly.</p>
                    <div class="features">
                        <p>Whether you're looking to expand your network by adding new contacts, or keeping your current connections updated and organized, CORE Contacts provides a seamless way to manage it all. The 'Add' feature enables you to swiftly input new contacts, capturing essential details such as name, email, and social handles. The dynamic 'Search' functionality lets you instantly locate the information you need, right when you need it. Should the need arise to modify contact details, the 'Edit' option is a straightforward affair, making updates a breeze. Lastly, the 'Delete' function allows you to declutter your contact list, offering you a clean, focused interface, without the distractions of obsolete or irrelevant connections.</p>
                        <p>Now, lets dive in...</p>
                        {/*<!-- Add: Importing Contacts -->*/}
                        <div class="feature-item">
                            <h3>➕ Add</h3>
                            <p>Populate Your CORE with the contacts that matter.</p>
                        </div>
                        <h3>Step-by-Step Instructions:</h3>
                        <ol>
                            <li>Click the 'New' button located at the base of the right sidebar, below your contact list and to the right of the search bar.</li>
                            <li>A contact form will appear in the main content area, replacing the blog post.</li>
                            <li>Fill in the fields for the first and last name, email, Twitter username, and notes.</li>
                            <li>If this contact is especially important, click the star button to highlight them in Your CORE list.</li>
                            <li>Click 'Save' to add the contact, or 'Cancel' to discard the changes.</li>
                        </ol>
                        <h3>Author's Story:</h3>
                        <p>When I first launched my business, my immediate challenge was collecting all my scattered contacts into one place. Spreadsheet management was tiresome, and it was slowing me down.</p>
                        <p>With CORE Contacts, I easily added each contact one-by-one, even using the multi-purpose note section to jot down specifics about my relationship with each. These details became invaluable later.</p>
                        <p>This simple addition process made my life easier, increasing efficiency and ensuring I never missed an opportunity to connect with someone crucial to my business.</p>

                        {/*<!-- Search: Dynamic Query -->*/}
                        <div class="feature-item">
                            <h3>🔍 Search</h3>
                            <p>Find exactly what you're looking for, instantly.</p>
                        </div>
                        <h3>Step-by-Step Instructions:</h3>
                        <ol>
                            <li>Locate the search bar at the bottom of the right sidebar in Your CORE.</li>
                            <li>Start typing the name of the contact you're looking for.</li>
                            <li>Your CORE will dynamically filter the list as you type, showing only the relevant matches.</li>
                        </ol>
                        <h3>Author's Story:</h3>
                        <p>I was at a conference, and I bumped into someone who had e-mailed me a week earlier. I needed to recall his details fast to steer the conversation correctly.</p>
                        <p>The dynamic search in CORE Contacts allowed me to start typing his first name into Your CORE on my phone, and instantly his full details popped up—right down to the Twitter username and our e-mail conversation notes.</p>
                        <p>What could have been an awkward situation turned into a meaningful discussion that led to a successful partnership, all thanks to the quick search function.</p>

                        {/*<!-- Edit: Modify Details -->*/}
                        <div class="feature-item">
                            <h3>✏️ Edit</h3>
                            <p>Change happens. Keep your contacts up-to-date.</p>
                        </div>
                        <h3>Step-by-Step Instructions:</h3>
                        <ol>
                            <li>Find the contact you wish to edit in Your CORE list.</li>
                            <li>Click on the contact's name to go to their details page.</li>
                            <li>Click the 'Edit' button.</li>
                            <li>Make the necessary changes in the contact form.</li>
                            <li>Click 'Save' to update the contact, or 'Cancel' to discard the changes.</li>
                        </ol>
                        <h3>Author's Story:</h3>
                        <p>A previous client changed roles and moved to a new company. She reached out to me to let me know her new contact details.</p>
                        <p>Within seconds, I updated her details in CORE Contacts. When she later messaged me about a new project, I already had her updated info and could reply with context and relevance.</p>
                        <p>Keeping my contacts updated meant that when opportunities knocked, I was already at the door, ready to greet them.</p>

                        {/*<!-- Delete: Remove Unnecessary Contacts -->*/}
                        <div class="feature-item">
                            <h3>🗑️ Delete</h3>
                            <p>Unclutter Your CORE by removing what you don't need.</p>
                        </div>
                        <h3>Step-by-Step Instructions:</h3>
                        <ol>
                            <li>Find the contact you wish to delete in Your CORE list.</li>
                            <li>Click on the contact's name to go to their details page.</li>
                            <li>Click the 'Delete' button.</li>
                            <li>An alert will pop up asking you to confirm the deletion. Press 'OK' to confirm or 'Cancel' to keep the contact.</li>
                        </ol>
                        <h3>Author's Story:</h3>
                        <p>While reviewing my contacts, I noticed several from a project that had been wrapped up long ago. Keeping them seemed counterproductive.</p>
                        <p>Deleting these contacts freed up my CORE Contacts list, making it more streamlined and focused on my current priorities. </p>
                        <p>By decluttering my contact list, I was not only tidying up a digital space but also making room for new, impactful relationships.</p>
                    </div>
                </div>
                {/*<section className="subsection">*/}
                {/*    <h2>Welcome Messages</h2>*/}
                {/*    <h3>A tagline for Welcome Messages</h3>*/}
                {/*    <p>Your introductory text about welcome messages.</p>*/}
                {/*    <ul>*/}
                {/*        <li><img className="blog-header" src={blogHeader} alt="ContactBlog header" /></li>*/}
                {/*    </ul>*/}

                {/*    <h2>Welcome Messages</h2>*/}
                {/*    <h3>A tagline for Welcome Messages</h3>*/}
                {/*    <p>Your introductory text about welcome messages.</p>*/}
                {/*    <ul>*/}
                {/*        <li><img className="blog-header" src={blogHeader} alt="ContactBlog header" /></li>*/}
                {/*    </ul>*/}

                {/*    <h2>Welcome Messages</h2>*/}
                {/*    <h3>A tagline for Welcome Messages</h3>*/}
                {/*    <p>Your introductory text about welcome messages.</p>*/}
                {/*    <ul>*/}
                {/*        <li><img className="blog-header" src={blogHeader} alt="ContactBlog header" /></li>*/}
                {/*    </ul>*/}
                {/*</section>*/}
            </div>
        </>
    );
};

export default ContactBlog;