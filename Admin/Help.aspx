<%@ Page Title="Help" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="Help.aspx.vb" Inherits="Admin_Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div style="border:4px ridge black; border-radius:5px; width:1000px;position:relative; left: 100px; padding-right:100px;">
<center><h1><u><b>User Guide</b></u></h1></center>

<p style="font-size:1.3em">If you would like a more in-depth guide to using this Content Management System, <a target="_blank" href="./images/CMS_User_Guide.pdf" style="font-size:1.1em;color:Blue;">click here.</a></p>

<h2><u>Pages</u></h2>

<p>The pages of the website are always shown on the far left
once you are logged in to the content management area. The top section shows
the current menu structure of the pages, replicating how they are shown in the
main website menu. To change the order of the menu you can drag and drop each
page to where you want it to be. To create a new parent-child structure, you
can drag one page on top of another. Once you have changed the sorting of the
pages, please click the <b>Save Order</b> button to commit them. </p>

<p>The colour of the page name indicates its status. Red means the page is unpublished and blue means the page is awaiting approval.</p>

<p>The list of pages beneath the menu pages are those which
exist in the website but are not needed on the main menu. </p>

<p>Click on a page name to bring up the details of that page.
In here you will be able to edit the page itself, its search engine details and
the status of the page.
    The definition of each is below:</p>
    <ul style="position:relative; left:100px">
        <li>Page Title - what is displayed on the menu </li>
        <li>Page URL – used to navigate to the web page (usually the same as title but with spaces removed) </li>
        <li>Keywords – these help search engines display what the page is about </li>
        <li>Description – a description of the page for search engines </li>
        <li>Page Status – the status of the page. This can be Published, Unpublished or Awaiting Approval </li>
        <li>Show in Menu – sets if the page is shown in the main menu of the website </li>
    </ul>

<p>You can edit the content of a page in a similar way you to
how you would a word document. You can edit the font size, colour
and type as well as adding links to other pages and documents. </p>

<p>To add images click this button<img src="../Images/imagebutton.png" />.
This will show you all the current images uploaded in the past. You can select
any of these to use or click the <b>Upload </b>button
to add a new one. Once the image has been selected, click <b>Insert </b>to add it to the page. You can also change the size of the
image, the description and border whilst in this view. </p>

<p>To add documents such as doc or pdf, click this button<img src="../Images/documentbutton.png" />.
Again this will show you all the files that have been added before. The difference
between this and the images button is that using this will create text link to
the selected file rather than displaying it in the web page. </p>

<p>Use the <b>Parent Page </b> drop-down menu to specify where you would like the page to be on the main website's navigation menu.
For example, choosing 'Subjects' as the Parent Page will place the page in the drop-down menu for Subjects. You can also specify
if you'd like the newly-created page to have no Parent Page.</p>

<p>Once you are happy with the changes you have made, click the
<b>Save</b> button. This will put the page
in a state of saved but not published. This means you can work on some changes
to a page without changing the live website. When you want to update the website
with these changes, click <b>Publish</b>.</p>

<p>If for any reason you want to remove a page from the
website, you can use the <b>Unpublish</b> button.<b> </b>This
will keep the page in the system but users of the web site will not be able to
view it. </p>

<p>To completely delete the page from the system, use the <b>Delete </b>button. This means you
cannot recover the page afterwards, so make sure you want to delete it first! </p>

<p>The <b>Revert</b> button
will reset and saved changes back to what is live on the web site. </p>

<h2><u>Security</u></h2>

<p>All users with access to the system are displayed in a list
to the left. It shows their full name and their login name in brackets. Selecting
one of these users will display further details on them.</p>

<p>To change a user’s password, simply enter it twice in the <b>Password</b> box and again in the <b >Confirm Password</b> box. On saving, this
will be changed. </p>

<p>The <b>User Role </b>selector
sets what permissions that user has. If it is set to <b>Approver, </b>the user edit and publish
changes as they wish. If it is set to <b>Editor,
</b>that user can only edit content. An approver will need to publish any
changes an Editor makes.</p>

<p>The page permissions area enables permissions per page for
what each user can edit. For example, if you only wanted teachers to edit their
own class pages you would only tick that page in the permissions area. </p>

<p>Once changes have been made to the user details or the
permission, click the <b>Save</b> button to
submit these. If the <b>Approver </b>role is selected, all pages will be permitted upon saving the user. </p>

<p>To add a new user, click the <b>Add New</b> button. This will prompt you for a login name for the new
user. Clicking <b>Save </b>will create the
user and let you complete the rest of the details.</p>

<p>To delete a user, click the <b>Delete</b> button. This will delete the User from the system entirely.</p>

<h2><u>Events</u></h2>

<p>All events currently in the system are displayed under the Events tab. Clicking one of these will bring up the full details of the event.
In here you can set the start and finish times, the description of the event
and whether or not you want that event to appear in the events box on the home
page. </p>

<p>To add a new event, whilst viewing an existing one, click
the <b>Add New</b> button. This will prompt
for a date and description. Clicking the <b>Save</b>
button will add the event.</p>

<p>To remove an event, simply click the <b>Delete</b> button.</p>

<p><u>Security</u></p>

<p>All users with access to the system are displayed in a list
to the left. It shows their full name and their login name in brackets. Selecting
one of these users will display further details on them.</p>

<p>To change a user’s password, simply enter it twice in the <b>Password</b> box and again in the <b >Confirm Password</b> box. On saving, this
will be changed. </p>

<p>The <b>User Role </b>selector
sets what permissions that user has. If it is set to <b>Approver, </b>the user edit and publish
changes as they wish. If it is set to <b>Editor,
</b>that user can only edit content. An approver will need to publish and
changes and Editor makes.</p>

<p>The page permissions area enables permissions per page for
what each user can edit. For example, if you only wanted teachers to edit their
own class pages you would only tick that page in the permissions area. </p>

<p>Once changes have been made to the user details or the
permission, click the <b>Save</b> button to
submit these. </p>

<p>To add a new user, click the <b>Add New</b> button. This will prompt you for a login name for the new
user. Clicking <b>Save </b>will create the
user and let you complete the rest of the details.</p>

<p><u>Home Page Images</u></p>

<p>The 3 images at the top of the page are selected randomly
from a folder called <b>Home Page</b> in
the image uploads area. Please ensure there are always at least 3 images in
here. There is no maximum limit for these. When you upload any images, please ensure that it is prefixed with IMG_, for example, IMG_SchoolPicture.
This is so that the website can filter out files that aren't images for the Home Page header. Any images uploaded ideally need to be 
400 pixels x 300 pixels in size in order to display in the triangles correctly. </p>

</asp:Content>