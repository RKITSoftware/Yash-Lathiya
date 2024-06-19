export default function showCustomStore() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div id='heading'></div>
    <div class='row'>
      <div id='selectBox'></div>
    </div>
    <div class='row'>
      <div id='byKey'></div>
    </div>
    <div class='row'>
      <div id='clear'></div>
    </div>
    <div class='row'>
      <div id='createQuery'></div>
    </div>
    <div class='row'>
      <div id='insert'></div>
    </div>
    <div class='row'>
      <div id='key'></div>
    </div>
    <div class='row'>
      <div id='keyOf'></div>
    </div>
    <div class='row'>
      <div id='load'></div>
    </div>
    <div class='row'>
      <div id='push'></div>
    </div>
    <div class='row'>
      <div id='remove'></div>
    </div>
    <div class='row'>
      <div id='totalCount'></div>
    </div>
    <div class='row'>
      <div id='update'></div>
    </div>`
  );

  $("#heading").dxButton({
    text: "Custom Store",
    onClick: () => {
      console.log(store);
    },
  });

  var store = new DevExpress.data.CustomStore({
    key: "id",

    // loadMode: "row",

    // cacheRowData: true,

    loadMode: "processed", // default value => processed , accepted value => processed, row

    byKey: (key) => {
      var d = $.Deferred();
      $.get("https://jsonplaceholder.typicode.com/todos/" + key).done(
        (dataItem) => {
          d.resolve(dataItem);
        }
      );
      return d.promise();
    },

    load: function (loadOptions) {
      // ... custom load implementation
    },

    insert: function (values) {
      return $.ajax({
        url: "https://jsonplaceholder.typicode.com/todos",
        method: "POST",
        data: values,
      });
    },

    update: function (key, values) {
      return $.ajax({
        url: "https://jsonplaceholder.typicode.com/todos/" + key,
        method: "PUT",
        data: values,
      });
    },

    remove: function (key) {
      return $.ajax({
        url: "https://jsonplaceholder.typicode.com/todos/" + key,
        method: "DELETE",
      });
    },

    onInserting: (values) => {
      console.log("*inserting..", "values", values);
    },
    onInserted: (values, key) => {
      console.log("*inserted..", "key", key, "values", values);
    },
    onLoaded: (result) => {
      console.log("*loaded..", "result", result);
    },
    onLoading: (loadOptions) => {
      console.log("*loading..", "loadOptions", loadOptions);
    },
    onModified: () => {
      console.log("*modified..");
    },
    onModifying: () => {
      console.log("*modifying..");
    },
    onPush: () => {
      console.log("*push");
    },
    onRemoving: (key) => {
      console.log("*removing..", "key", key);
    },
    onRemoved: (key) => {
      console.log("*removed..", "key", key);
    },
    onUpdated: (key, values) => {
      console.log("*updated..", "key", key, "values", values);
    },
    onUpdating: (key, values) => {
      console.log("*updating..", "key", key, "values", values);
    },
    errorHandler: (err) => {
      console.log("err", err);
    },
  });

  $("#byKey").dxButton({
    text: "By Key (1)",
    onClick: () => {
      store
        .byKey(1)
        .done((dataItem) => {
          console.log("done", "dataItem", dataItem);
        })
        .fail((err) => {
          console.log("fail", err);
        });
    },
  });
}
