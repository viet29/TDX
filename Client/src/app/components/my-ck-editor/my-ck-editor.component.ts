import { Component, OnInit, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import * as customBuild from '../ckCustomBuild/build/ckeditor';

@Component({
  selector: 'app-my-ck-editor',
  templateUrl: './my-ck-editor.component.html',
  styleUrls: ['./my-ck-editor.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => MyCkEditorComponent),
      multi: true
    }
  ]
})
export class MyCkEditorComponent implements OnInit, ControlValueAccessor {

  public Editor = customBuild;
  @Input() readonly: boolean = false;

  private _value: string = '';

  get value() {
    return this._value;
  }

  set value(v: string) {
    if (v !== this._value) {
      this._value = v;
      this.onChange(v);
    }
  }

  constructor() { }

  onChange(v) {

  }
  onTouch() { }

  writeValue(obj: any): void {
    this._value = obj;

  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouch = fn;
  }


  ngOnInit(): void {
  }

  title = 'ckeditorAngular10';
  @Input() config = {
    toolbar: {
      items: [
        'heading', '|',
        'fontfamily', 'fontsize',
        'alignment',
        'fontColor', 'fontBackgroundColor', '|',
        'bold', 'italic', 'strikethrough', 'underline', 'subscript', 'superscript', '|',
        'link', '|',
        'outdent', 'indent', '|',
        'bulletedList', '-', 'numberedList', 'todoList', '|',
        'code', 'codeBlock', '|',
        'insertTable', '|',
        'imageUpload', 'blockQuote', '|',
        'todoList'
        ,
        'undo', 'redo',
      ],
      shouldNotGroupWhenFull: true,

    },
    image: {
      // Configure the available styles.
      styles: [
        'alignLeft', 'alignCenter', 'alignRight'
      ],

      // Configure the available image resize options.
      resizeOptions: [
        {
          name: 'resizeImage:original',
          label: 'Original',
          value: null
        },
        {
          name: 'resizeImage:50',
          label: '25%',
          value: '25'
        },
        {
          name: 'resizeImage:50',
          label: '50%',
          value: '50'
        },
        {
          name: 'resizeImage:75',
          label: '75%',
          value: '75'
        }
      ],

      // You need to configure the image toolbar, too, so it shows the new style
      // buttons as well as the resize buttons.
      toolbar: [
        'imageStyle:alignLeft', 'imageStyle:alignCenter', 'imageStyle:alignRight',
        '|',
        'ImageResize',
        '|',
        'imageTextAlternative'
      ]
    },
    // simpleUpload: {
    //    The URL that the images are uploaded to.
    // uploadUrl: 'http://localhost:52536/api/Image/ImageUpload',

    //   Enable the XMLHttpRequest.withCredentials property.

    //},

    language: 'vi'
  };

  onReady(editor) {
    if (editor.model.schema.isRegistered('image')) {
      editor.model.schema.extend('image', { allowAttributes: 'blockIndent' });
    }
  }
}
